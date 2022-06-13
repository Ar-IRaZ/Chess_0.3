using ChessLibrary.MainMenu;
using ChessLibrary.Scenes;
using System;
using System.Collections.Generic;

namespace ChessLibrary.EscapeMenu
{
    internal class SaveScene : ISceneSourse
    {
        List<ISceneItem> items;
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