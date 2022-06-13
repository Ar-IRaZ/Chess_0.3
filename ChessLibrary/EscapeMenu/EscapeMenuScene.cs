﻿using ChessLibrary.MainMenu;
using ChessLibrary.Scenes;
using System;
using System.Collections.Generic;

namespace ChessLibrary.EscapeMenu
{
    public class EscapeMenuScene : ISceneSourse
    {
        private IEnumerable<ISceneItem> _sceneItems;

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