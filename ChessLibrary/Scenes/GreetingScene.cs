using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary.Scenes
{
    public class GreetingScene : ISceneSourse
    {
       
        public void PrintScene()
        {
            Console.WriteLine(new string(' ', 36)+"Greeting!"+ new string(' ',35));            
        }

        private string Read()
        {
            throw new NotImplementedException();
        }

        public void UpdateScene(List<ISceneItem> items)
        {
            throw new NotImplementedException();
        }

        
    }
}
