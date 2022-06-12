using ChessLibrary.MainMenu;
using ChessLibrary.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary.Authorization
{
    public class SingInScene : ISceneSourse
    {
        private List<ISceneItem> Scene { get; set; }

        public void PrintScene()
        {
            Console.Clear();
            foreach(MenuSceneItems item in Scene)
            {
                Console.Write(item.Str);
            }
        }

        public void UpdateScene(List<ISceneItem> sceneItems)
        {
            Scene = sceneItems;
        }
    }
}
