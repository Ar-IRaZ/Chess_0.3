﻿using ChessLibrary.Game;
using ChessLibrary.MainMenu;
using ChessLibrary.Scenes.Game;
using System;
using System.Collections.Generic;

namespace ChessLibrary.EscapeMenu
{
    internal class EscapeMenuGamePart : GamePart
    {
        private int _selectedLine = 0;
        
        private GamePart currentGamePart { get; set; }
        public EscapeMenuGamePart(GamePart part)
        {
            currentGamePart = part;
        }      

        public override List<ISceneItem> GetScene()
        {
            List<ISceneItem> sceneItems = new List<ISceneItem>() {  new MenuSceneItems(new string(' ', 80) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 33) + "Resume"  + new string(' ', 32)+ '\n', _selectedLine == 0 ? true : false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 35) + "Save Game"  + new string(' ', 35)+ '\n', _selectedLine == 1 ? true : false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 36) + "Setting"  + new string(' ', 36)+ '\n', _selectedLine == 2 ? true : false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 36) + "Log Out"  + new string(' ', 36)+ '\n', _selectedLine == 3 ? true : false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 37) + "Exite"  + new string(' ', 37)+ '\n', _selectedLine == 4 ? true : false),
                                                                                new MenuSceneItems(new string(' ', 80), false)};

            return sceneItems;
        }

        public override void ReadInput()
        {
        Here: switch (Console.ReadKey(true).Key)
            {

                case ConsoleKey.UpArrow:
                    if (_selectedLine - 1 >= 0)
                        _selectedLine--;
                    else
                        _selectedLine = 4;
                    break;


                case ConsoleKey.DownArrow:
                    if (_selectedLine + 1 <= 4)
                        _selectedLine++;
                    else
                        _selectedLine = 0;
                    break;


                case ConsoleKey.Enter:
                    switch (_selectedLine)
                    {
                        case 0:                            
                            App.SetGamePart(currentGamePart);
                            App.SetScene(new ConsoleGameScene());
                            break;

                        case 1:
                            //App.SetGamePart();
                            //App.SetScene();
                            break;

                        case 2:
                            //App.SetGamePart();
                            //App.SetScene();
                            break;

                        case 3:
                            //App.SetGamePart();
                            //App.SetScene();
                            break;

                        case 4:
                            //App.SetGamePart();
                            //App.SetScene();
                            break;

                        default:
                            throw new Exception("Out of menu range");
                    }
                    break;


                case ConsoleKey.Escape:

                    break;


                default:
                    goto Here;
            }
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}