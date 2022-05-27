using System;
using System.Reflection;
using ChessLibrary.Game;
using ChessLibrary.Scenes;

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
            Scene scene = new Scene(new GameScene());           
            Game game = new Game("rnbqkbnr/8/8/3ppp2/2PPP3/8/8/RNBQKBNR w KQkq - 0 1", null,null);
            game.UpdateBoard();
            while (true)
            {
                
                scene.UpdateScene(game.GetScene());
                scene.PrintScene();
                
                game.ReadInput();
                
            }
           


        }
    }
}
