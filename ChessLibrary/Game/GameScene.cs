using ChessLibrary.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary.Scenes.Game
{
    public class ConsoleGameScene : ISceneSourse
    {
        private List<ISceneItem> Scene { get; set ; }

        public ConsoleGameScene()
        {
            
            
        }

        public void PrintScene()
        {
            if (Scene != null)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                foreach (GameSceneItem sceneItem in Scene)
                {
                    if (sceneItem.CursoreSelected)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = SetColor(sceneItem.ForegroundColor);
                        Console.Write(sceneItem.Str);
                        Console.ForegroundColor = SetColor(Color.none);
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    else if (sceneItem.PossibleMove)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = SetColor(sceneItem.ForegroundColor);
                        Console.Write(sceneItem.Str);
                        Console.ForegroundColor = SetColor(Color.none);
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    else
                    {
                        Console.BackgroundColor = SetColor(sceneItem.BackgroundColor);
                        Console.ForegroundColor = SetColor(sceneItem.ForegroundColor);
                        Console.Write(sceneItem.Str);
                        Console.ForegroundColor = SetColor(Color.none);
                        Console.BackgroundColor = SetColor(Color.none);                        
                    }
                }
            }
            else
                Console.WriteLine("Scene is not set yet");
        }


        private ConsoleColor SetColor(Color colorItem)
        {
            switch(colorItem)
            {
                case Color.red:
                    return ConsoleColor.Red;

                case Color.blue:
                    return ConsoleColor.Blue;

                case Color.white:
                    return ConsoleColor.White;

                case Color.black:
                    return ConsoleColor.Black;

                case Color.darckGray:
                    return ConsoleColor.DarkGray;

                default:
                   return ConsoleColor.Black;
            }
        }
        
        public void UpdateScene(List<ISceneItem> sceneItems)
        {
            Scene = sceneItems;
        }        
    }
}
