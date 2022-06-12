using System;
using System.Reflection;
using ChessLibrary;
using ChessLibrary.Authorization;
using ChessLibrary.Game;
using ChessLibrary.MainMenu;
using ChessLibrary.Scenes;
using ChessLibrary.Scenes.Game;

namespace Chess_0._3
{
    class Program
    {
        static void Main()
        {
            //Type type = typeof(GreetingScene);
            //Console.WriteLine(type.AssemblyQualifiedName);
            //Console.WriteLine(type.FullName);


            //ConstructorInfo[] constructors = Type.GetType(app.Default.DefaultSceneSourceName).GetConstructors();
            //Scene scene = new Scene((ISceneSourse)constructors[0].Invoke(null));

            //Scene scene = new Scene(new ConsoleGameScene());
            //GamePart game = new ConsoleGame("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1", null, null);
            //game.Update();

            Scene scene = new Scene(new MainMenuScene());
            GamePart game = new MainMenuGamePart();
            //Scene scene = new Scene(new LogInOrSingInScene());
            //GamePart game = new LogInOrSingInGamePart();
            App app = new App(game,scene);

            app.StartApp();
            
            
        }
    }
}
