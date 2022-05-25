using ChessLibrary.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary.Scenes
{
    public class GameScene : ISceneSourse
    {
        private List<ISceneItem> Scene { get; set ; }

        public GameScene()
        {
            
            
        }

        public void PrintScene()
        {
            if (Scene != null)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                foreach (GameSceneItem sceneItem in Scene)
                {
                    if (sceneItem.CursoreSelected)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(sceneItem.Str);
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                        Console.Write(sceneItem.Str);
                }
            }
            else
                Console.WriteLine("Scene is not set yet");
        }

        public void UpdateScene(List<ISceneItem> sceneItems)
        {
            Scene = sceneItems;
        }

        
    }
}
