using ChessLibrary.MainMenu;
using ChessLibrary.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary.Authorization
{
    public class LogInOrSingInGamePart : GamePart
    {
        private int _selectedLine = 0;


        public override List<ISceneItem> GetScene()
        {
            List<ISceneItem> sceneItems = new List<ISceneItem>() {  new MenuSceneItems(new string(' ', 80) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 80) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 80) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 80) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 38) + "SingIn"  + new string(' ', 35)+ '\n', _selectedLine == 0 ? true : false),
                                                                                new MenuSceneItems(new string(' ', 80) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 38) + "LogIn"  + new string(' ', 36)+ '\n', _selectedLine == 1 ? true : false),
                                                                                new MenuSceneItems(new string(' ', 80) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 38) + "Exite"  + new string(' ', 36)+ '\n', _selectedLine == 2 ? true : false),
                                                                                new MenuSceneItems(new string(' ', 40), false)};

            return sceneItems;
        }

        public override void ReadInput()
        {
            
            Here: switch(Console.ReadKey(true).Key)
            {

                case ConsoleKey.UpArrow:
                    if (_selectedLine-1 >= 0)
                        _selectedLine--;
                    else
                        _selectedLine = 2;
                    break;


                case ConsoleKey.DownArrow:
                    if (_selectedLine+1 <= 2)
                        _selectedLine++;
                    else
                        _selectedLine = 0;
                    break;


                case ConsoleKey.Enter:
                    switch (_selectedLine)
                    {
                        case 0:
                            App.SetGamePart(new SingInGamePart());
                            App.SetScene(new SingInScene());
                            break;

                        case 1:
                            App.SetGamePart(new LogInGamePart());
                            App.SetScene(new LogInScene());
                            break;

                        case 2:
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
            throw new NotImplementedException();
        }
    }
}
