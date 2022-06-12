using ChessLibrary.MainMenu;
using ChessLibrary.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary.Authorization
{
    class LogInScene : ISceneSourse
    {
        private List<ISceneItem> items { get; set; }

        public void PrintScene()
        {
            Console.Clear();
            foreach(MenuSceneItems item in items)
            {
                Console.Write(item.Str);
            }
        }

        public void UpdateScene(List<ISceneItem> sceneItems)
        {
            items = sceneItems;
        }
    }
}
