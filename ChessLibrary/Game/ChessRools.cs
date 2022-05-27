using ChessLibrary.Game;
using System;
using System.Collections.Generic;

namespace ChessLibrary
{
    public static class ChessRools
    {
        public static List<Figure> whiteFigures = new List<Figure>() { Figure.whiteKing, Figure.whiteBishop, Figure.whiteKnight, Figure.whitePawn, Figure.whiteQueen, Figure.whiteRook };
        public static List<Figure> blackFigures = new List<Figure>() { Figure.blackKing, Figure.blackBishop, Figure.blackKnight, Figure.blackPawn, Figure.blackQueen, Figure.blackRook };

        public static void GetPossibleMove(Board board)
        {

            switch (board.Squares[board.CursoreSelected[0], board.CursoreSelected[1]].Figure)
            {
                case Figure.blackPawn:
                    PawnMove(board);
                    break;

                case Figure.whitePawn:
                    PawnMove(board);
                    break;

                case Figure.whiteQueen:
                    QueenMove(board);
                    break;

                case Figure.blackQueen:
                    QueenMove(board);
                    break;

                case Figure.blackKnight:
                    KnightMove(board);
                    break;
                case Figure.whiteKnight:
                    KnightMove(board);
                    break;

                case Figure.whiteBishop:
                    BishopMove(board);
                    break;

                case Figure.blackBishop:
                    BishopMove(board);
                    break;

                case Figure.whiteRook:
                    RookMove(board);
                    break;

                case Figure.blackRook:
                    RookMove(board);
                    break;

                default:
                    break;
            }

        }
        private static void RookMove(Board board)
        {
            int x = board.CursoreSelected[1];
            int y = board.CursoreSelected[0];
            board.Squares[y, x].MovePossibility = true;
            int i;
            if (board.Squares[y, x].Figure == Figure.whiteRook)
            {

                #region Down
                for (i = y + 1; i < 8; i++)
                {
                    if (board.Squares[i, x].Figure == Figure.none)
                    {
                        board.Squares[i, x].MovePossibility = true;
                    }
                    else if (blackFigures.Contains(board.Squares[i, x].Figure))
                    {
                        board.Squares[i, x].MovePossibility = true;                        
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region Up
                for (i = y - 1; i >= 0; i--)
                {
                    if (board.Squares[i, x].Figure == Figure.none)
                    {
                        board.Squares[i, x].MovePossibility = true;
                    }
                    else if (blackFigures.Contains(board.Squares[i, x].Figure))
                    {
                        board.Squares[i, x].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region Right
                for (i = x + 1; i < 8; i++)
                {
                    if (board.Squares[y, i].Figure == Figure.none)
                    {
                        board.Squares[y, i].MovePossibility = true;
                    }
                    else if (blackFigures.Contains(board.Squares[y, i].Figure))
                    {
                        board.Squares[y, i].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region Left
                for (i = x - 1; i >= 0; i--)
                {
                    if (board.Squares[y, i].Figure == Figure.none)
                    {
                        board.Squares[y, i].MovePossibility = true;
                    }
                    else if (blackFigures.Contains(board.Squares[y, i].Figure))
                    {
                        board.Squares[y, i].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion
            }
            else
            {
                #region Down
                for (i = y + 1; i < 8; i++)
                {
                    if (board.Squares[i, x].Figure == Figure.none)
                    {
                        board.Squares[i, x].MovePossibility = true;
                    }
                    else if (whiteFigures.Contains(board.Squares[i, x].Figure))
                    {
                        board.Squares[i, x].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region Up
                for (i = y - 1; i >= 0; i--)
                {
                    if (board.Squares[i, x].Figure == Figure.none)
                    {
                        board.Squares[i, x].MovePossibility = true;
                    }
                    else if (whiteFigures.Contains(board.Squares[i, x].Figure))
                    {
                        board.Squares[i, x].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region Right
                for (i = x + 1; i < 8; i++)
                {
                    if (board.Squares[y, i].Figure == Figure.none)
                    {
                        board.Squares[y, i].MovePossibility = true;
                    }
                    else if (whiteFigures.Contains(board.Squares[y, i].Figure))
                    {
                        board.Squares[y, i].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region Left
                for (i = x - 1; i >= 0; i--)
                {
                    if (board.Squares[y, i].Figure == Figure.none)
                    {
                        board.Squares[y, i].MovePossibility = true;
                    }
                    else if (whiteFigures.Contains(board.Squares[y, i].Figure))
                    {
                        board.Squares[y, i].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion
            }
        }
        private static void BishopMove(Board board)
        {
            int x = board.CursoreSelected[1];
            int y = board.CursoreSelected[0];
            board.Squares[y, x].MovePossibility = true;
            if (board.Squares[y, x].Figure == Figure.whiteBishop)
            {
                #region RightDown
                int i = y + 1;
                int j = x + 1;
                while (j < 8 && i < 8)
                {
                    if (board.Squares[i, j].Figure == Figure.none)
                    {
                        board.Squares[i, j].MovePossibility = true;
                        j++;
                        i++;
                    }
                    else if (blackFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[i, j].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region RightUp
                i = y - 1;
                j = x + 1;
                while (j < 8 && i >= 0)
                {
                    if (board.Squares[i, j].Figure == Figure.none)
                    {
                        board.Squares[i, j].MovePossibility = true;
                        j++;
                        i--;
                    }
                    else if (blackFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[i, j].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region LeftUp
                i = y - 1;
                j = x - 1;
                while (j >= 0 && i >= 0)
                {
                    if (board.Squares[i, j].Figure == Figure.none)
                    {
                        board.Squares[i, j].MovePossibility = true;
                        j--;
                        i--;
                    }
                    else if (blackFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[i, j].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region LeftDown
                i = y + 1;
                j = x - 1;

                while (j >= 0 && i < 8)
                {
                    if (board.Squares[i, j].Figure == Figure.none)
                    {
                        board.Squares[i, j].MovePossibility = true;
                        j--;
                        i++;
                    }
                    else if (blackFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[i, j].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }

                #endregion
            } else
            {
                #region RightDown
                int i = y + 1;
                int j = x + 1;
                while (j < 8 && i < 8)
                {
                    if (board.Squares[i, j].Figure == Figure.none)
                    {
                        board.Squares[i, j].MovePossibility = true;
                        j++;
                        i++;
                    }
                    else if (whiteFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[i, j].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region RightUp
                i = y - 1;
                j = x + 1;
                while (j < 8 && i >= 0)
                {
                    if (board.Squares[i, j].Figure == Figure.none)
                    {
                        board.Squares[i, j].MovePossibility = true;
                        j++;
                        i--;
                    }
                    else if (whiteFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[i, j].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region LeftUp
                i = y - 1;
                j = x - 1;
                while (j >= 0 && i >= 0)
                {
                    if (board.Squares[i, j].Figure == Figure.none)
                    {
                        board.Squares[i, j].MovePossibility = true;
                        j--;
                        i--;
                    }
                    else if (whiteFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[i, j].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region LeftDown
                i = y + 1;
                j = x - 1;

                while (j >= 0 && i < 8)
                {
                    if (board.Squares[i, j].Figure == Figure.none)
                    {
                        board.Squares[i, j].MovePossibility = true;
                        j--;
                        i++;
                    }
                    else if (whiteFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[i, j].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }

                #endregion
            }

        }
        private static void QueenMove(Board board)
        {
            int x = board.CursoreSelected[1];
            int y = board.CursoreSelected[0];
            board.Squares[y, x].MovePossibility = true;
            if (board.Squares[y, x].Figure == Figure.whiteQueen)
            {
                #region RightDown
                int i = y + 1;
                int j = x + 1;
                while (j < 8 && i < 8)
                {
                    if (board.Squares[i, j].Figure == Figure.none)
                    {
                        board.Squares[i, j].MovePossibility = true;
                        j++;
                        i++;
                    }
                    else if (blackFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[i, j].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region RightUp
                i = y - 1;
                j = x + 1;
                while (j < 8 && i >= 0)
                {
                    if (board.Squares[i, j].Figure == Figure.none)
                    {
                        board.Squares[i, j].MovePossibility = true;
                        j++;
                        i--;
                    }
                    else if (blackFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[i, j].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region LeftUp
                i = y - 1;
                j = x - 1;
                while (j >= 0 && i >= 0)
                {
                    if (board.Squares[i, j].Figure == Figure.none)
                    {
                        board.Squares[i, j].MovePossibility = true;
                        j--;
                        i--;
                    }
                    else if (blackFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[i, j].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region LeftDown
                i = y + 1;
                j = x - 1;

                while (j >= 0 && i < 8)
                {
                    if (board.Squares[i, j].Figure == Figure.none)
                    {
                        board.Squares[i, j].MovePossibility = true;
                        j--;
                        i++;
                    }
                    else if (blackFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[i, j].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }

                #endregion

                #region Down
                for (i = y + 1; i < 8; i++)
                {
                    if (board.Squares[i, x].Figure == Figure.none)
                    {
                        board.Squares[i, x].MovePossibility = true;
                    }
                    else if (blackFigures.Contains(board.Squares[i, x].Figure))
                    {
                        board.Squares[i, x].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region Up
                for (i = y - 1; i >= 0; i--)
                {
                    if (board.Squares[i, x].Figure == Figure.none)
                    {
                        board.Squares[i, x].MovePossibility = true;
                    }
                    else if (blackFigures.Contains(board.Squares[i, x].Figure))
                    {
                        board.Squares[i, x].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region Right
                for (i = x + 1; i < 8; i++)
                {
                    if (board.Squares[y, i].Figure == Figure.none)
                    {
                        board.Squares[y, i].MovePossibility = true;
                    }
                    else if (blackFigures.Contains(board.Squares[y, i].Figure))
                    {
                        board.Squares[y, i].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region Left
                for (i = x - 1; i >= 0; i--)
                {
                    if (board.Squares[y, i].Figure == Figure.none)
                    {
                        board.Squares[y, i].MovePossibility = true;
                    }
                    else if (blackFigures.Contains(board.Squares[y, i].Figure))
                    {
                        board.Squares[y, i].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion
            }
            if (board.Squares[y, x].Figure == Figure.blackQueen)
            {
                #region RightDown
                int i = y + 1;
                int j = x + 1;
                while (j < 8 && i < 8)
                {
                    if (board.Squares[i, j].Figure == Figure.none)
                    {
                        board.Squares[i, j].MovePossibility = true;
                        j++;
                        i++;
                    }
                    else if (whiteFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[i, j].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region RightUp
                i = y - 1;
                j = x + 1;
                while (j < 8 && i >= 0)
                {
                    if (board.Squares[i, j].Figure == Figure.none)
                    {
                        board.Squares[i, j].MovePossibility = true;
                        j++;
                        i--;
                    }
                    else if (whiteFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[i, j].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region LeftUp
                i = y - 1;
                j = x - 1;
                while (j >= 0 && i >= 0)
                {
                    if (board.Squares[i, j].Figure == Figure.none)
                    {
                        board.Squares[i, j].MovePossibility = true;
                        j--;
                        i--;
                    }
                    else if (whiteFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[i, j].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region LeftDown
                i = y + 1;
                j = x - 1;

                while (j >= 0 && i < 8)
                {
                    if (board.Squares[i, j].Figure == Figure.none)
                    {
                        board.Squares[i, j].MovePossibility = true;
                        j--;
                        i++;
                    }
                    else if (whiteFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[i, j].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }

                #endregion

                #region Down
                for (i = y + 1; i < 8; i++)
                {
                    if (board.Squares[i, x].Figure == Figure.none)
                    {
                        board.Squares[i, x].MovePossibility = true;
                    }
                    else if (whiteFigures.Contains(board.Squares[i, x].Figure))
                    {
                        board.Squares[i, x].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region Up
                for (i = y - 1; i >= 0; i--)
                {
                    if (board.Squares[i, x].Figure == Figure.none)
                    {
                        board.Squares[i, x].MovePossibility = true;
                    }
                    else if (whiteFigures.Contains(board.Squares[i, x].Figure))
                    {
                        board.Squares[i, x].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region Right
                for (i = x + 1; i < 8; i++)
                {
                    if (board.Squares[y, i].Figure == Figure.none)
                    {
                        board.Squares[y, i].MovePossibility = true;
                    }
                    else if (whiteFigures.Contains(board.Squares[y, i].Figure))
                    {
                        board.Squares[y, i].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region Left
                for (i = x - 1; i >= 0; i--)
                {
                    if (board.Squares[y, i].Figure == Figure.none)
                    {
                        board.Squares[y, i].MovePossibility = true;
                    }
                    else if (whiteFigures.Contains(board.Squares[y, i].Figure))
                    {
                        board.Squares[y, i].MovePossibility = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion
            }
        }
        private static void KnightMove(Board board)
        {
            int x = board.CursoreSelected[1];
            int y = board.CursoreSelected[0];
            board.Squares[y, x].MovePossibility = true;
            if (board.Squares[y, x].Figure == Figure.whiteKnight)
            {
                try
                {
                    if (!whiteFigures.Contains(board.Squares[y - 2, x - 1].Figure))
                    {
                        board.Squares[y - 2, x - 1].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//UpLeft

                try
                {
                    if (!whiteFigures.Contains(board.Squares[y - 2, x + 1].Figure))
                    {
                        board.Squares[y - 2, x + 1].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//UpRight

                try
                {
                    if (!whiteFigures.Contains(board.Squares[y + 2, x + 1].Figure))
                    {
                        board.Squares[y + 2, x + 1].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//DownRight

                try
                {
                    if (!whiteFigures.Contains(board.Squares[y + 2, x - 1].Figure))
                    {
                        board.Squares[y + 2, x - 1].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//DownLeft

                try
                {
                    if (!whiteFigures.Contains(board.Squares[y - 1, x - 2].Figure))
                    {
                        board.Squares[y - 1, x - 2].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//LeftUp

                try
                {
                    if (!whiteFigures.Contains(board.Squares[y - 1, x + 2].Figure))
                    {
                        board.Squares[y - 1, x + 2].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//RightUp

                try
                {
                    if (!whiteFigures.Contains(board.Squares[y + 1, x + 2].Figure))
                    {
                        board.Squares[y + 1, x + 2].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//RightDown

                try
                {
                    if (!whiteFigures.Contains(board.Squares[y + 1, x - 2].Figure))
                    {
                        board.Squares[y + 1, x - 2].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//LeftDown
            }
            else
            {
                try
                {
                    if (!blackFigures.Contains(board.Squares[y - 2, x - 1].Figure))
                    {
                        board.Squares[y - 2, x - 1].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//DownRight+

                try
                {
                    if (!blackFigures.Contains(board.Squares[y - 2, x + 1].Figure))
                    {
                        board.Squares[y - 2, x + 1].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//DownLeft+

                try
                {
                    if (!blackFigures.Contains(board.Squares[y + 2, x + 1].Figure))
                    {
                        board.Squares[y + 2, x + 1].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//UpLeft+

                try
                {
                    if (!blackFigures.Contains(board.Squares[y + 2, x - 1].Figure))
                    {
                        board.Squares[y + 2, x - 1].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//UpRight+

                try
                {
                    if (!blackFigures.Contains(board.Squares[y - 1, x - 2].Figure))
                    {
                        board.Squares[y - 1, x - 2].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//RightDown+

                try
                {
                    if (!blackFigures.Contains(board.Squares[y - 1, x + 2].Figure))
                    {
                        board.Squares[y - 1, x + 2].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//LeftDown+

                try
                {
                    if (!blackFigures.Contains(board.Squares[y + 1, x + 2].Figure))
                    {
                        board.Squares[y + 1, x + 2].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//LeftUp+

                try
                {
                    if (!blackFigures.Contains(board.Squares[y + 1, x - 2].Figure))
                    {
                        board.Squares[y + 1, x - 2].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//RightUp+
            }
        }
        private static void PawnMove(Board board)
        {
            int x = board.CursoreSelected[1];
            int y = board.CursoreSelected[0];
            board.Squares[y, x].MovePossibility = true;
            if (board.Squares[y, x].Figure == Figure.whitePawn)
            {
                try
                {
                    if (blackFigures.Contains(board.Squares[y - 1, x - 1].Figure))
                    {
                        board.Squares[y - 1, x - 1].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//Left

                try
                {
                    if (blackFigures.Contains(board.Squares[y - 1, x + 1].Figure))
                    {
                        board.Squares[y - 1, x + 1].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//Rigth

                try
                {
                    if (board.Squares[y - 1, x].Figure == Figure.none)
                    {
                        board.Squares[y - 1, x].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    //Реалізація зміни фігури
                }//Forward

                if (y == 6)
                {
                    try
                    {
                        if (board.Squares[y - 2, x].Figure == Figure.none)
                        {
                            board.Squares[y - 2, x].MovePossibility = true;
                        }
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        //Реалізація зміни фігури
                    }//Forward 2
                }
            }
            if (board.Squares[y, x].Figure == Figure.blackPawn)
            {
                try
                {
                    if (whiteFigures.Contains(board.Squares[y + 1, x + 1].Figure))
                    {
                        board.Squares[y + 1, x + 1].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//Left

                try
                {
                    if (whiteFigures.Contains(board.Squares[y + 1, x - 1].Figure))
                    {
                        board.Squares[y + 1, x - 1].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//Rigth

                try
                {
                    if (board.Squares[y + 1, x].Figure == Figure.none)
                    {
                        board.Squares[y + 1, x].MovePossibility = true;
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    //Реалізація зміни фігури
                }//Forward
                if (y == 1)
                {
                    try
                    {
                        if (board.Squares[y + 2, x].Figure == Figure.none)
                        {
                            board.Squares[y + 2, x].MovePossibility = true;
                        }
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        //Реалізація зміни фігури
                    }//Forward 2
                }
            }
        }

        private static void KingMove(Board board)
        {
            
        }

        private static bool IsCheck(Board board, Fen fen)
        {
            Square whiteKing=null, blackKing=null, cursoreSelected = null; 
            foreach(Square sq in board.Squares)
            {
                if (sq.Figure == Figure.whiteKing)
                    whiteKing = sq;
                if (sq.Figure == Figure.blackKing)
                    blackKing = sq;
                if (sq.CursoreSelected)
                    cursoreSelected = sq;
                if (whiteKing != null && blackKing != null && cursoreSelected !=null)
                    break;
            }

            foreach(Square sq in board.Squares)
            {
                Board b = new Board().CreateBoard(fen);
                b.CursoreSelected = new int[2] { sq.YCoordinate,sq.XCoordinate };
                if(sq.Figure != Figure.none)
                    if(whiteFigures.Contains(sq.Figure))
                    {
                        GetPossibleMove(b);
                    }
            }
            return false;
        }// not implimented
    }
}