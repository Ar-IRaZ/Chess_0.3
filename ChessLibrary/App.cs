using ChessLibrary.Game;
using ChessLibrary.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class App
    {
        private static GamePart GamePart { get; set; }
        private static Scene Scene { get; set; }
        public static Player Player { get; private set; }
        
        public App(Player player)
        {
            Player = player;
        }
        public App(GamePart gamePart, Scene scene)
        {
            GamePart = gamePart;
            Scene = scene;
            Player = null;
        }
        public App(Player player, GamePart gamePart , Scene scene )
        {
            Player = player;
            GamePart = gamePart;
            Scene = scene;
        }

        public void StartApp()
        {
            while (true)
            {
                Scene.UpdateScene(GamePart.GetScene());
                Scene.PrintScene();

                GamePart.ReadInput();
            }
        }       

        public static void SetGamePart(GamePart part)
        {
            GamePart = part;
        }

        public static void SetScene(ISceneSourse scene)
        {
            Scene.SetSoure(scene);
        }
    }
}
