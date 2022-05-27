using ChessLibrary.Game;
using System;
using System.Collections.Generic;

namespace ChessLibrary
{
    public static class ChessRools
    {
        public static List<Figure> whiteFigures = new List<Figure>() { Figure.whiteKing, Figure.whiteBishop, Figure.whiteKnight, Figure.whitePawn, Figure.whiteQueen, Figure.whiteRook };
        public static List<Figure> blackFigures = new List<Figure>() { Figure.blackKing, Figure.blackBishop, Figure.blackKnight, Figure.blackPawn, Figure.blackQueen, Figure.blackRook };

        public static void GetPossibleMove(Square sq, Board board)
        {

            switch (sq.Figure)
            {
                case Figure.blackPawn:
                    PawnMove(sq, board);
                    break;

                case Figure.whitePawn:
                    PawnMove(sq, board);
                    break;

                case Figure.whiteQueen:
                    QueenMove(sq, board);
                    break;

                case Figure.blackQueen:
                    QueenMove(sq, board);
                    break;

                case Figure.blackKnight:
                    KnightMove(sq, board);
                    break;
                case Figure.whiteKnight:
                    KnightMove(sq, board);
                    break;

                case Figure.whiteBishop:
                    BishopMove(sq, board);
                    break;

                case Figure.blackBishop:
                    BishopMove(sq, board);
                    break;

                case Figure.whiteRook:
                    RookMove(sq, board);
                    break;

                case Figure.blackRook:
                    RookMove(sq, board);
                    break;

                case Figure.whiteKing:
                    KingMove(sq, board);
                    break; 
                    
                case Figure.blackKing:
                    KingMove(sq, board);
                    break;

                default:
                    break;
            }

        }


        private static void RookMove(Square sq, Board board)
        {
            int x = sq.XCoordinate;
            int y = sq.YCoordinate;
            board.Squares[y, x].FiguresCanMove.Add(board.Squares[y,x]);
            int i;
            if (board.Squares[y, x].Figure == Figure.whiteRook)
            {

                #region Down
                for (i = y + 1; i < 8; i++)
                {
                    if (board.Squares[i, x].Figure == Figure.none)
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, x]);
                    }
                    else if (blackFigures.Contains(board.Squares[i, x].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, x]);
                        if (board.Squares[i, x].Figure == Figure.blackKing)
                            board.IsBlackCheck = true;
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, x]);
                    }
                    else if (blackFigures.Contains(board.Squares[i, x].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, x]);
                        if (board.Squares[i, x].Figure == Figure.blackKing)
                            board.IsBlackCheck = true;
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, i]);
                    }
                    else if (blackFigures.Contains(board.Squares[y, i].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, i]);
                        if (board.Squares[y, i].Figure == Figure.blackKing)
                            board.IsBlackCheck = true;
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, i]);
                    }
                    else if (blackFigures.Contains(board.Squares[y, i].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, i]);
                        if (board.Squares[y, i].Figure == Figure.blackKing)
                            board.IsBlackCheck = true;
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, x]);
                    }
                    else if (whiteFigures.Contains(board.Squares[i, x].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, x]);
                        if (board.Squares[i, x].Figure == Figure.whiteKing)
                            board.IsWhiteCheck = true;
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, x]);
                    }
                    else if (whiteFigures.Contains(board.Squares[i, x].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, x]);
                        if (board.Squares[i, x].Figure == Figure.whiteKing)
                            board.IsWhiteCheck = true;
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, i]);
                    }
                    else if (whiteFigures.Contains(board.Squares[i, x].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, i]);
                        if (board.Squares[y, i].Figure == Figure.whiteKing)
                            board.IsWhiteCheck = true;
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, i]);
                    }
                    else if (whiteFigures.Contains(board.Squares[i, x].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, i]);
                        if (board.Squares[y, i].Figure == Figure.whiteKing)
                            board.IsWhiteCheck = true;
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

        private static void BishopMove(Square sq, Board board)
        {
            int x = sq.XCoordinate;
            int y = sq.YCoordinate;
            board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, x]);
            if (board.Squares[y, x].Figure == Figure.whiteBishop)
            {
                #region RightDown
                int i = y + 1;
                int j = x + 1;
                while (j < 8 && i < 8)
                {
                    if (board.Squares[i, j].Figure == Figure.none)
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        j++;
                        i++;
                    }
                    else if (blackFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        if (board.Squares[i, j].Figure == Figure.blackKing)
                        {
                            board.IsBlackCheck = true;
                        }
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        j++;
                        i--;
                    }
                    else if (blackFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        if (board.Squares[i, j].Figure == Figure.blackKing)
                        {
                            board.IsBlackCheck = true;
                        }
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        j--;
                        i--;
                    }
                    else if (blackFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        if (board.Squares[i, j].Figure == Figure.blackKing)
                        {
                            board.IsBlackCheck = true;
                        }
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        j--;
                        i++;
                    }
                    else if (blackFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        if (board.Squares[i, j].Figure == Figure.blackKing)
                        {
                            board.IsBlackCheck = true;
                        }
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
                #region RightDown
                int i = y + 1;
                int j = x + 1;
                while (j < 8 && i < 8)
                {
                    if (board.Squares[i, j].Figure == Figure.none)
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        j++;
                        i++;
                    }
                    else if (whiteFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        if (board.Squares[i, j].Figure == Figure.whiteKing)
                        {
                            board.IsWhiteCheck = true;
                        }
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        j++;
                        i--;
                    }
                    else if (whiteFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        if (board.Squares[i, j].Figure == Figure.whiteKing)
                        {
                            board.IsWhiteCheck = true;
                        }
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        j--;
                        i--;
                    }
                    else if (whiteFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        if (board.Squares[i, j].Figure == Figure.whiteKing)
                        {
                            board.IsWhiteCheck = true;
                        }
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        j--;
                        i++;
                    }
                    else if (whiteFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        if (board.Squares[i, j].Figure == Figure.whiteKing)
                        {
                            board.IsWhiteCheck = true;
                        }
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

        private static void QueenMove(Square sq, Board board)
        {
            int x = sq.XCoordinate;
            int y = sq.YCoordinate;
            board.Squares[y, x].FiguresCanMove.Add(board.Squares[y,x]);
            if (board.Squares[y, x].Figure == Figure.whiteQueen)
            {
                #region RightDown
                int i = y + 1;
                int j = x + 1;
                while (j < 8 && i < 8)
                {
                    if (board.Squares[i, j].Figure == Figure.none)
                    {
                        board.Squares[y,x].FiguresCanMove.Add(board.Squares[i, j]);
                        j++;
                        i++;
                    }
                    else if (blackFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        if(board.Squares[i, j].Figure == Figure.blackKing)
                        {
                            board.IsBlackCheck = true;
                        }
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        j++;
                        i--;
                    }
                    else if (blackFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        if (board.Squares[i, j].Figure == Figure.blackKing)
                        {
                            board.IsBlackCheck = true;
                        }
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        j--;
                        i--;
                    }
                    else if (blackFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        if (board.Squares[i, j].Figure == Figure.blackKing)
                        {
                            board.IsBlackCheck = true;
                        }
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        j--;
                        i++;
                    }
                    else if (blackFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        if (board.Squares[i, j].Figure == Figure.blackKing)
                        {
                            board.IsBlackCheck = true;
                        }
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
                        board.Squares[y,x].FiguresCanMove.Add(board.Squares[i, x]);
                    }
                    else if (blackFigures.Contains(board.Squares[i, x].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, x]);
                        if (board.Squares[i, x].Figure == Figure.blackKing)
                            board.IsBlackCheck = true;
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, x]);
                    }
                    else if (blackFigures.Contains(board.Squares[i, x].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, x]);
                        if (board.Squares[i, x].Figure == Figure.blackKing)
                            board.IsBlackCheck = true;
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, i]);
                    }
                    else if (blackFigures.Contains(board.Squares[y, i].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, i]);
                        if (board.Squares[y, i].Figure == Figure.blackKing)
                            board.IsBlackCheck = true;
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, i]);
                    }
                    else if (blackFigures.Contains(board.Squares[y, i].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, i]);
                        if (board.Squares[y, i].Figure == Figure.blackKing)
                            board.IsBlackCheck = true;
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        j++;
                        i++;
                    }
                    else if (whiteFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        if (board.Squares[i, j].Figure == Figure.whiteKing)
                        {
                            board.IsWhiteCheck = true;
                        }
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        j++;
                        i--;
                    }
                    else if (whiteFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        if (board.Squares[i, j].Figure == Figure.whiteKing)
                        {
                            board.IsWhiteCheck = true;
                        }
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        j--;
                        i--;
                    }
                    else if (whiteFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        if (board.Squares[i, j].Figure == Figure.whiteKing)
                        {
                            board.IsWhiteCheck = true;
                        }
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        j--;
                        i++;
                    }
                    else if (whiteFigures.Contains(board.Squares[i, j].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, j]);
                        if (board.Squares[i, j].Figure == Figure.whiteKing)
                        {
                            board.IsWhiteCheck = true;
                        }
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, x]);
                    }
                    else if (whiteFigures.Contains(board.Squares[i, x].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, x]);
                        if (board.Squares[i, x].Figure == Figure.whiteKing)
                            board.IsWhiteCheck = true;
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, x]);
                    }
                    else if (whiteFigures.Contains(board.Squares[i, x].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[i, x]);
                        if (board.Squares[i, x].Figure == Figure.whiteKing)
                            board.IsWhiteCheck = true;
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, i]);
                    }
                    else if (whiteFigures.Contains(board.Squares[i, x].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, i]);
                        if (board.Squares[y, i].Figure == Figure.whiteKing)
                            board.IsWhiteCheck = true;
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, i]);
                    }
                    else if (whiteFigures.Contains(board.Squares[i, x].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, i]);
                        if (board.Squares[y, i].Figure == Figure.whiteKing)
                            board.IsWhiteCheck = true;
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

        private static void KnightMove(Square sq, Board board)
        {
            int x = sq.XCoordinate;
            int y = sq.YCoordinate;
            board.Squares[y,x].FiguresCanMove.Add(board.Squares[y, x]);
            if (board.Squares[y, x].Figure == Figure.whiteKnight)
            {
                try
                {
                    if (!whiteFigures.Contains(board.Squares[y - 2, x - 1].Figure))
                    {
                        board.Squares[y,x].FiguresCanMove.Add(board.Squares[y - 2, x - 1]);
                        if (board.Squares[y - 2, x - 1].Figure == Figure.blackKing)
                        {
                            board.IsBlackCheck = true;
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//UpLeft

                try
                {
                    if (!whiteFigures.Contains(board.Squares[y - 2, x + 1].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y - 2, x + 1]);
                        if(board.Squares[y - 2, x + 1].Figure==Figure.blackKing)
                        {
                            board.IsBlackCheck = true;
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//UpRight

                try
                {
                    if (!whiteFigures.Contains(board.Squares[y + 2, x + 1].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y + 2, x + 1]);
                        if (board.Squares[y + 2, x + 1].Figure == Figure.blackKing)
                        {
                            board.IsBlackCheck = true;
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//DownRight

                try
                {
                    if (!whiteFigures.Contains(board.Squares[y + 2, x - 1].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y + 2, x - 1]);
                        if (board.Squares[y + 2, x - 1].Figure == Figure.blackKing)
                        {
                            board.IsBlackCheck = true;
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//DownLeft

                try
                {
                    if (!whiteFigures.Contains(board.Squares[y - 1, x - 2].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y - 1, x - 2]);
                        if (board.Squares[y - 1, x - 2].Figure == Figure.blackKing)
                        {
                            board.IsBlackCheck = true;
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//LeftUp

                try
                {
                    if (!whiteFigures.Contains(board.Squares[y - 1, x + 2].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y - 1, x + 2]);
                        if (board.Squares[y - 1, x + 2].Figure == Figure.blackKing)
                        {
                            board.IsBlackCheck = true;
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//RightUp

                try
                {
                    if (!whiteFigures.Contains(board.Squares[y + 1, x + 2].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y + 1, x + 2]);
                        if (board.Squares[y + 1, x + 2].Figure == Figure.blackKing)
                        {
                            board.IsBlackCheck = true;
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//RightDown

                try
                {
                    if (!whiteFigures.Contains(board.Squares[y + 1, x - 2].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y + 1, x - 2]);
                        if (board.Squares[y + 1, x - 2].Figure == Figure.blackKing)
                        {
                            board.IsBlackCheck = true;
                        }
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y - 2, x - 1]);
                        if (board.Squares[y - 2, x - 1].Figure == Figure.whiteKing)
                        {
                            board.IsWhiteCheck = true;
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//DownRight+

                try
                {
                    if (!blackFigures.Contains(board.Squares[y - 2, x + 1].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y - 2, x + 1]);
                        if (board.Squares[y - 2, x + 1].Figure == Figure.whiteKing)
                        {
                            board.IsWhiteCheck = true;
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//DownLeft+

                try
                {
                    if (!blackFigures.Contains(board.Squares[y + 2, x + 1].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y + 2, x + 1]);
                        if (board.Squares[y + 2, x + 1].Figure == Figure.whiteKing)
                        {
                            board.IsWhiteCheck = true;
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//UpLeft+

                try
                {
                    if (!blackFigures.Contains(board.Squares[y + 2, x - 1].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y + 2, x - 1]);
                        if (board.Squares[y + 2, x - 1].Figure == Figure.whiteKing)
                        {
                            board.IsWhiteCheck = true;
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//UpRight+

                try
                {
                    if (!blackFigures.Contains(board.Squares[y - 1, x - 2].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y - 1, x - 2]);
                        if (board.Squares[y - 1, x - 2].Figure == Figure.whiteKing)
                        {
                            board.IsWhiteCheck = true;
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//RightDown+

                try
                {
                    if (!blackFigures.Contains(board.Squares[y - 1, x + 2].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y - 1, x + 2]);
                        if (board.Squares[y - 1, x + 2].Figure == Figure.whiteKing)
                        {
                            board.IsWhiteCheck = true;
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//LeftDown+

                try
                {
                    if (!blackFigures.Contains(board.Squares[y + 1, x + 2].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y + 1, x + 2]);
                        if (board.Squares[y + 1, x + 2].Figure == Figure.whiteKing)
                        {
                            board.IsWhiteCheck = true;
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//LeftUp+

                try
                {
                    if (!blackFigures.Contains(board.Squares[y + 1, x - 2].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y + 1, x - 2]);
                        if (board.Squares[y + 1, x - 2].Figure == Figure.whiteKing)
                        {
                            board.IsWhiteCheck = true;
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//RightUp+
            }
        }

        private static void PawnMove(Square sq,Board board)
        {
            int x = sq.XCoordinate;
            int y = sq.YCoordinate;
            board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, x]);
            if (board.Squares[y, x].Figure == Figure.whitePawn)
            {
                try
                {
                    if (blackFigures.Contains(board.Squares[y - 1, x - 1].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y - 1, x - 1]);
                        if (board.Squares[y - 1, x - 1].Figure == Figure.blackKing)
                        {
                            board.IsBlackCheck = true;
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//Left

                try
                {
                    if (blackFigures.Contains(board.Squares[y - 1, x + 1].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y - 1, x + 1]);
                        if (board.Squares[y - 1, x + 1].Figure == Figure.blackKing)
                        {
                            board.IsBlackCheck = true;
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//Rigth

                try
                {
                    if (board.Squares[y - 1, x].Figure == Figure.none)
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y - 1, x]);
                        if (board.Squares[y - 1, x].Figure == Figure.blackKing)
                        {
                            board.IsBlackCheck = true;
                        }
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
                            board.Squares[y, x].FiguresCanMove.Add(board.Squares[y - 2, x]);
                            if (board.Squares[y - 2, x].Figure == Figure.blackKing)
                            {
                                board.IsBlackCheck = true;
                            }
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
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y + 1, x + 1]);
                        if (board.Squares[y + 1, x + 1].Figure == Figure.whiteKing)
                        {
                            board.IsWhiteCheck = true;
                        }

                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//Left

                try
                {
                    if (whiteFigures.Contains(board.Squares[y + 1, x - 1].Figure))
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y + 1, x - 1]);
                        if (board.Squares[y + 1, x - 1].Figure == Figure.whiteKing)
                        {
                            board.IsWhiteCheck = true;
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//Rigth

                try
                {
                    if (board.Squares[y + 1, x].Figure == Figure.none)
                    {
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y + 1, x]);
                        if (board.Squares[y + 1, x].Figure == Figure.whiteKing)
                        {
                            board.IsWhiteCheck = true;
                        }
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
                            board.Squares[y, x].FiguresCanMove.Add(board.Squares[y + 2, x]);
                            if (board.Squares[y + 2, x].Figure == Figure.whiteKing)
                            {
                                board.IsWhiteCheck = true;
                            }
                        }
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        
                    }//Forward 2
                }
            }
        }

        private static void KingMove(Square sq, Board board)
        {
            int x = sq.XCoordinate;
            int y = sq.YCoordinate;

            if (board.Squares[y,x].Figure == Figure.whiteKing)
            {
                
                try
                {
                    if(!whiteFigures.Contains(board.Squares[y-1, x].Figure))
                    {
                        bool k = false;
                        foreach(Square squa in board.Squares)
                        {
                            if(blackFigures.Contains(squa.Figure))
                            {
                                if(squa.FiguresCanMove.Contains(board.Squares[y-1,x]))
                                {
                                    k = true;
                                }                                
                            }
                        }
                        if(!k)
                        board.Squares[y, x].FiguresCanMove.Add(board.Squares[y - 1, x]);

                    }
                }
                catch(IndexOutOfRangeException e)
                {

                }//-1;0

                try
                {
                    if (!whiteFigures.Contains(board.Squares[y - 1, x-1].Figure))
                    {
                        bool k = false;
                        foreach (Square squa in board.Squares)
                        {
                            if (blackFigures.Contains(squa.Figure))
                            {
                                if (squa.FiguresCanMove.Contains(board.Squares[y - 1, x-1]))
                                {
                                    k = true;
                                }
                            }
                        }
                        if (!k)
                            board.Squares[y, x].FiguresCanMove.Add(board.Squares[y - 1, x - 1]);

                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//-1;-1

                try
                {
                    if (!whiteFigures.Contains(board.Squares[y, x-1].Figure))
                    {
                        bool k = false;
                        foreach (Square squa in board.Squares)
                        {
                            if (blackFigures.Contains(squa.Figure))
                            {
                                if (squa.FiguresCanMove.Contains(board.Squares[y, x-1]))
                                {
                                    k = true;
                                }
                            }
                        }
                        if (!k)
                            board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, x-1]);

                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//0;-1

                try
                {
                    if (!whiteFigures.Contains(board.Squares[y + 1, x].Figure))
                    {
                        bool k = false;
                        foreach (Square squa in board.Squares)
                        {
                            if (blackFigures.Contains(squa.Figure))
                            {
                                if (squa.FiguresCanMove.Contains(board.Squares[y + 1, x]))
                                {
                                    k = true;
                                }
                            }
                        }
                        if (!k)
                            board.Squares[y, x].FiguresCanMove.Add(board.Squares[y + 1, x]);

                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//+1;0

                try
                {
                    if (!whiteFigures.Contains(board.Squares[y + 1, x+1].Figure))
                    {
                        bool k = false;
                        foreach (Square squa in board.Squares)
                        {
                            if (blackFigures.Contains(squa.Figure))
                            {
                                if (squa.FiguresCanMove.Contains(board.Squares[y + 1, x + 1]))
                                {
                                    k = true;
                                }
                            }
                        }
                        if (!k)
                            board.Squares[y, x].FiguresCanMove.Add(board.Squares[y + 1, x + 1]);

                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//+1;+1

                try
                {
                    if (!whiteFigures.Contains(board.Squares[y, x+1].Figure))
                    {
                        bool k = false;
                        foreach (Square s in board.Squares)
                        {
                            if (blackFigures.Contains(s.Figure))
                            {
                                if (s.FiguresCanMove.Contains(board.Squares[y, x+1]))
                                {
                                    k = true;
                                }
                            }
                        }
                        if (!k)
                            board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, x+1]);

                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//0;+1

                try
                {
                    if (!whiteFigures.Contains(board.Squares[y-1, x+1].Figure))
                    {
                        bool k = false;
                        foreach (Square s in board.Squares)
                        {
                            if (blackFigures.Contains(s.Figure))
                            {
                                if (s.FiguresCanMove.Contains(board.Squares[y-1, x+1]))
                                {
                                    k = true;
                                }
                            }
                        }
                        if (!k)
                            board.Squares[y, x].FiguresCanMove.Add(board.Squares[y-1, x+1]);

                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//-1;+1

                try
                {
                    if (!whiteFigures.Contains(board.Squares[y+1, x-1].Figure))
                    {
                        bool k = false;
                        foreach (Square s in board.Squares)
                        {
                            if (blackFigures.Contains(s.Figure))
                            {
                                if (s.FiguresCanMove.Contains(board.Squares[y+1, x-1]))
                                {
                                    k = true;
                                }
                            }
                        }
                        if (!k)
                            board.Squares[y, x].FiguresCanMove.Add(board.Squares[y+1, x-1]);

                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//+1;-1
                 
                if(board.IsWhiteCheck)
                {
                    if(board.Squares[y,x].FiguresCanMove.Count==0)
                    {
                        //Game over!
                    }                    
                }
                else
                    board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, x]);

            }
            else
            {
                try
                {
                    if (!blackFigures.Contains(board.Squares[y-1, x].Figure))
                    {
                        bool k = false;
                        foreach (Square s in board.Squares)
                        {
                            if (whiteFigures.Contains(s.Figure))
                            {
                                if (s.FiguresCanMove.Contains(board.Squares[y-1, x]))
                                {
                                    k = true;
                                }
                            }
                        }
                        if (!k)
                            board.Squares[y, x].FiguresCanMove.Add(board.Squares[y-1, x]);

                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//-1;0

                try
                {
                    if (!blackFigures.Contains(board.Squares[y-1, x-1].Figure))
                    {
                        bool k = false;
                        foreach (Square s in board.Squares)
                        {
                            if (whiteFigures.Contains(s.Figure))
                            {
                                if (s.FiguresCanMove.Contains(board.Squares[y-1, x-1]))
                                {
                                    k = true;
                                }
                            }
                        }
                        if (!k)
                            board.Squares[y, x].FiguresCanMove.Add(board.Squares[y-1, x-1]);

                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//-1;-1

                try
                {
                    if (!blackFigures.Contains(board.Squares[y, x-1].Figure))
                    {
                        bool k = false;
                        foreach (Square s in board.Squares)
                        {
                            if (whiteFigures.Contains(s.Figure))
                            {
                                if (s.FiguresCanMove.Contains(board.Squares[y, x-1]))
                                {
                                    k = true;
                                }
                            }
                        }
                        if (!k)
                            board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, x-1]);

                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//0;-1

                try
                {
                    if (!blackFigures.Contains(board.Squares[y+1, x].Figure))
                    {
                        bool k = false;
                        foreach (Square s in board.Squares)
                        {
                            if (whiteFigures.Contains(s.Figure))
                            {
                                if (s.FiguresCanMove.Contains(board.Squares[y+1, x]))
                                {
                                    k = true;
                                }
                            }
                        }
                        if (!k)
                            board.Squares[y, x].FiguresCanMove.Add(board.Squares[y+1, x]);

                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//+1;0

                try
                {
                    if (!blackFigures.Contains(board.Squares[y+1, x+1].Figure))
                    {
                        bool k = false;
                        foreach (Square s in board.Squares)
                        {
                            if (whiteFigures.Contains(s.Figure))
                            {
                                if (s.FiguresCanMove.Contains(board.Squares[y+1, x+1]))
                                {
                                    k = true;
                                }
                            }
                        }
                        if (!k)
                            board.Squares[y, x].FiguresCanMove.Add(board.Squares[y+1, x+1]);

                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//+1;+1

                try
                {
                    if (!blackFigures.Contains(board.Squares[y, x+1].Figure))
                    {
                        bool k = false;
                        foreach (Square s in board.Squares)
                        {
                            if (whiteFigures.Contains(s.Figure))
                            {
                                if (s.FiguresCanMove.Contains(board.Squares[y, x+1]))
                                {
                                    k = true;
                                }
                            }
                        }
                        if (!k)
                            board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, x+1]);

                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//0;+1

                try
                {
                    if (!blackFigures.Contains(board.Squares[y-1, x+1].Figure))
                    {
                        bool k = false;
                        foreach (Square s in board.Squares)
                        {
                            if (whiteFigures.Contains(s.Figure))
                            {
                                if (s.FiguresCanMove.Contains(board.Squares[y-1, x+1]))
                                {
                                    k = true;
                                }
                            }
                        }
                        if (!k)
                            board.Squares[y, x].FiguresCanMove.Add(board.Squares[y-1, x+1]);

                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//-1;+1

                try
                {
                    if (!blackFigures.Contains(board.Squares[y+1, x-1].Figure))
                    {
                        bool k = false;
                        foreach (Square s in board.Squares)
                        {
                            if (whiteFigures.Contains(s.Figure))
                            {
                                if (s.FiguresCanMove.Contains(board.Squares[y+1, x-1]))
                                {
                                    k = true;
                                }
                            }
                        }
                        if (!k)
                            board.Squares[y, x].FiguresCanMove.Add(board.Squares[y+1, x-1]);

                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }//+1;-1

                if (board.IsBlackCheck)
                {
                    if (board.Squares[y, x].FiguresCanMove.Count == 0)
                    {
                        //Game over!
                    }
                }
                else
                    board.Squares[y, x].FiguresCanMove.Add(board.Squares[y, x]);
            }
            
        }        
    }
}