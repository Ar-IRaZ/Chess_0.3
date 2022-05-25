using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLibrary.Game
{
    public class Board
    {
        public Square[,] Squares { get; set; }
        public int[] CursoreSelected { get; set; }

        public void UpdateBoard()
        {
            
        }

        public Board CreateBoard(Fen fen)
        {
            Squares = new Square[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Squares[i, j] = new Square(fen.Figures[i,j],i,j);
                }
            }
            Squares[7, 0].CursoreSelected = true;
            CursoreSelected = new int[]{7, 0};
            return this;
        }
    }
}