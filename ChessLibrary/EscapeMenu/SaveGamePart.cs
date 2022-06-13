using ChessLibrary.Game;
using ChessLibrary.MainMenu;
using ChessLibrary.Models;
using ChessLibrary.Scenes.Game;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessLibrary.EscapeMenu
{
    internal class SaveGamePart : GamePart
    {
        private EscapeMenuGamePart escapeMenuGamePart;
        private List<ISceneItem> sceneItems;
        private int status = 0;

        public SaveGamePart(GamePart escapeMenuGamePart)
        {
            this.escapeMenuGamePart = (EscapeMenuGamePart)escapeMenuGamePart;
        }

        public override List<ISceneItem> GetScene()
        {
            switch (status)
            {

                case 0:
                    sceneItems = new List<ISceneItem>() {  new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                //Console.SetCursorPosition(12,6);
                                                                                new MenuSceneItems("Write name:"  + new string(' ', 68)+ '\n',true),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79), false)};
                    break;


                case 1:
                    sceneItems = new List<ISceneItem>() {  new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 37)+ "Saved!" + new string(' ', 36)+ '\n',true),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79), false)};
                    break;

                case 2:
                    sceneItems = new List<ISceneItem>() {  new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 32)+ "That name was used!" + new string(' ', 32)+ '\n',false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79), false)};
                    break;              


                default:
                    break;
            }
            return sceneItems;
        }

        public override void ReadInput()
        {
            using (GameContext context = new GameContext())
            {
                switch (status)
                {
                    #region 0
                    case 0:
                        Console.SetCursorPosition(12, 6);
                        string s = Console.ReadLine();
                        GameModel gm = null;
                        gm = context.Game
                                            .Where(p => p.Name == s)
                                            .FirstOrDefault();
                        if (gm == null)
                        {
                            gm = new GameModel();
                            gm.Name = s;
                            ConsoleGame g = (ConsoleGame)escapeMenuGamePart.currentGamePart;
                            gm.Fen = g.Fen.ToString();
                            context.Game.Add(gm);
                            context.SaveChanges();
                            status = 1;
                        }
                        else
                        {
                            status = 2;                            
                        }
                        break;
                    #endregion

                    #region 1
                    case 1:
                        Here2: if(Console.ReadKey(true).Key==ConsoleKey.Enter)
                        {

                            status = -1;
                            App.SetGamePart(escapeMenuGamePart.currentGamePart);
                            App.SetScene(new ConsoleGameScene());
                        }
                        else
                        {
                            goto Here2;
                        }
                        
                        break;
                    #endregion

                    #region 2
                    case 2:
                    Here: if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                        {
                            status = 0;
                        }
                        else
                        {
                            goto Here;
                        }

                        break;
                        #endregion
                }
            }
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}