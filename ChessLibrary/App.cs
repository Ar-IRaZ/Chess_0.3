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
        public Board Board { get; set; }
        public Scene Scene { get; set; }
        public static Player Player { get; private set; }
        
        public App(Player player)
        {
            Player = player;
        }
        public App(Player player, Board board, Scene scene)
        {
            Player = player;
        }
        public void StartApp()
        {

        }       
    }
}
