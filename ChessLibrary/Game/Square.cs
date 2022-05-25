using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChessLibrary.Game
{
    public class Square
    {
        //private SceneItems _menuItem;
        public Figure Figure { get; set; }
        public Color Color { get; set; }
       // public SceneItems SceneItems { get; set; }             
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public bool CursoreSelected { get; set; }
        

        public Square()
        {            
            Figure = Figure.none;
            Color = Color.none;
            //SceneItems = null;            
            XCoordinate = -1;
            YCoordinate = -1;
            CursoreSelected = false;
        }
        public Square(Figure figure, int y, int x)
        {
            Figure = figure;
            XCoordinate = x;
            YCoordinate = y;
            if ((x + y) % 2 == 0)
            {
                Color = Color.white;
            }
            else Color = Color.black;            
        }
    }
}