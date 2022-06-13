using ChessLibrary.Game;
using ChessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ChessLibrary.Scenes.Game;
using ChessLibrary.EscapeMenu;

namespace ChessLibrary.MainMenu
{
    public class LoadGameGamePart : GamePart
    {
        private int _selectedLine;

        private List<GameModel> Games { get; set; }
        public LoadGameGamePart()
        {
            
            using(GameContext context = new GameContext())
            {
                Games = context.Game
                        .Where(p => p.Name != null)                        
                        .ToList();
                _selectedLine = Games.Count - 1;
            }
        }
        public override List<ISceneItem> GetScene()
        {
            List<ISceneItem> sceneItems = new List<ISceneItem>() {  new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems("Select game:"  + new string(' ', 67) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false)};

            for(int i = Games.Count-1; i>=0;i--)
            {
                sceneItems.Add(new MenuSceneItems(new string(' ', 40-Games[i].Name.Length / 2) + Games[i].Name.ToString() + new string(' ', 39-Games[i].Name.Length / 2), i == _selectedLine ? true : false));
                sceneItems.Add(new MenuSceneItems(new string(' ', 79) + '\n', false));
            }                                                                                

            return sceneItems;
        }

        public override void ReadInput()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.DownArrow:
                    if (_selectedLine - 1 >= 0)
                        _selectedLine--;
                    else
                        _selectedLine = Games.Count-1;
                    break;


                case ConsoleKey.UpArrow:
                    if (_selectedLine + 1 <= Games.Count - 1)
                        _selectedLine++;
                    else
                        _selectedLine = 0;
                    break;


                case ConsoleKey.Enter:                
                        App.SetGamePart(new ConsoleGame(Games[_selectedLine].Fen,null,null));
                        App.SetScene(new ConsoleGameScene());
                    break;
            }
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}