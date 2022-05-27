using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary.Game
{
    public class GameSceneItem : ISceneItem
    {
        public string Str { get; set; }
        public bool CursoreSelected { get; set; }
        public bool PossibleMove { get; set; }
        //public Color SquareColor { get; set; }
        public Color BackgroundColor { get; set; }
        public Color ForegroundColor { get; set; }

        public GameSceneItem(string str,
                             bool cursoreSelected = false,
                             bool possibleMove = false,
                             Color backgraundColor = Color.none,
                             //Color squareColor =Color.none,
                             Color foregroundColor=Color.none)
        {
            CursoreSelected = cursoreSelected;
            Str = str;
            PossibleMove = possibleMove;
            //SquareColor = squareColor;
            BackgroundColor = backgraundColor;
            ForegroundColor = foregroundColor;
        }
    }
}
