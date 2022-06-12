using ChessLibrary.MainMenu;
using ChessLibrary.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary.Authorization
{
    public class LogInOrSingInScene : ISceneSourse
    {
        private List<ISceneItem> _sceneItems { get; set; }
        public void PrintScene()
        {
            Console.Clear();
            foreach (MenuSceneItems item in _sceneItems)
            {
                if (item.CursoreSelected)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(item.Str);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.Write(item.Str);
                }
            }
        }

        public void UpdateScene(List<ISceneItem> sceneItems)
        {
            _sceneItems = sceneItems;
        }
    }
}
