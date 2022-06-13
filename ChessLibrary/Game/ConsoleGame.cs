using ChessLibrary.EscapeMenu;
using ChessLibrary.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLibrary.Game
{
    public class ConsoleGame : GamePart
    {
        private int status;      //0 - Game continue, <0 - Game ended

        public Fen Fen { get; private set; }
        public Player WhitePlayer { get; set; }
        public Player BlackPlayer { get; set; }
        private Board Board { get; set; }
        private bool IsSelectedForMove { get; set; }
        private Square SelectedForMove { get; set; }


        public ConsoleGame(string fen, Player whitePlayer, Player blackPlayer)
        {
            status = 0;            
            Fen = new Fen(fen);
            WhitePlayer = whitePlayer;
            BlackPlayer = blackPlayer;
            IsSelectedForMove = false;
            Board = new Board().CreateBoard(Fen);
            Update();
        }

        private void SwapActiveSide()
        {
            if (Fen.ActiveSide == Color.black)
                Fen.ActiveSide = Color.white;
            else
                Fen.ActiveSide = Color.black;
        }

        public override List<ISceneItem> GetScene()
        {
            
            List<ISceneItem> items = new List<ISceneItem>();
            if (Fen.ActiveSide == Color.white)
            {
                #region UpLine+1st Line
                items.Add(new GameSceneItem("   +---+---+---+---+---+---+---+---+\n", false, false, Color.black, Color.black));
                items.Add(new GameSceneItem("   ", false, false, Color.black, Color.white));
                items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                items.Add(new GameSceneItem("+\n", false, false, Color.black, Color.black));
                #endregion
                for (int i = 0; i < 8; i++)
                {                    
                    items.Add(new GameSceneItem(' '+ (8-i).ToString()+" ", false, false, Color.black, Color.white));
                    items.Add(new GameSceneItem(new string('|', 1), false, false, Color.black, Color.black));
                    for(int j = 0; j < 8; j++)
                    {                                                        
                        items.Add(new GameSceneItem(new string(' ',1)+(char)Board.Squares[i,j].Figure+" ",
                                                    Board.Squares[i,j].CursoreSelected,
                                                    Board.Squares[i,j].MovePossibility,
                                                    SetColor(i,j),
                                                    SetColor(Board.Squares[i, j].Figure)));
                       
                        
                        if(j !=7)
                            items.Add(new GameSceneItem(new string('|', 1),
                                                    false,
                                                    false,
                                                    SetColor(i, j),
                                                    SetColor(i, j)));
                        else
                            items.Add(new GameSceneItem(new string('|', 1),
                                                    false,
                                                    false,
                                                    Color.black,
                                                    Color.black));
                    }
                    items.Add(new GameSceneItem("\n"));
                    if ((i + 1) % 8 != 0)
                    {
                        if (i % 2 == 1 )
                        {
                            items.Add(new GameSceneItem("   ", false, false, Color.black, Color.white));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem("+\n", false, false, Color.black, Color.black));
                        }
                        else
                        {
                            items.Add(new GameSceneItem("   ", false, false, Color.black, Color.white));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem("+\n", false, false, Color.black, Color.black));
                        }
                    }
                }
                items.Add(new GameSceneItem("   +---+---+---+---+---+---+---+---+\n", false, false, Color.black, Color.black));
                items.Add(new GameSceneItem("     A   B   C   D   E   F   G   H  \n", false, false, Color.black, Color.white));
            }
            else
            {
                #region UpLine+1st Line
                items.Add(new GameSceneItem("   +---+---+---+---+---+---+---+---+\n", false, false, Color.black, Color.black));
                items.Add(new GameSceneItem("   ", false, false, Color.black, Color.white));
                items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                items.Add(new GameSceneItem("+\n", false, false, Color.black, Color.black));
                #endregion

                for (int i = 7; i >= 0; i--)
                {
                    if ((i + 1) % 8 != 0)
                    {
                        if (i % 2 == 1)
                        {
                            items.Add(new GameSceneItem("   ", false, false, Color.black, Color.white));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem("+\n", false, false, Color.black, Color.black));
                        }
                        else
                        {
                            items.Add(new GameSceneItem("   ", false, false, Color.black, Color.white));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem("---", false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem(new string('+', 1), false, false, Color.black, Color.black));
                            items.Add(new GameSceneItem("---", false, false, Color.white, Color.white));
                            items.Add(new GameSceneItem("+\n", false, false, Color.white, Color.white));
                        }
                    }
                    items.Add(new GameSceneItem(' ' + (i + 1).ToString() + " ", false, false, Color.black, Color.white));
                    items.Add(new GameSceneItem(new string('|', 1), false, false, Color.black, Color.black));
                    for (int j = 7; j >= 0; j--)
                    {
                        items.Add(new GameSceneItem(new string(' ', 1) + (char)Board.Squares[i, j].Figure + " ",
                                                    Board.Squares[i, j].CursoreSelected,
                                                    Board.Squares[i, j].MovePossibility,
                                                    SetColor(i, j),
                                                    SetColor(Board.Squares[i, j].Figure)));
                        
                            items.Add(new GameSceneItem(new string('|', 1), false, false, SetColor(i, j), SetColor(i, j)));
                    }
                    items.Add(new GameSceneItem("\n"));
                    
                    
                }
                items.Add(new GameSceneItem("   +---+---+---+---+---+---+---+---+\n", false, false, Color.black, Color.black));
                items.Add(new GameSceneItem("     H   G   А   E   D   C   B   A  \n",false, false, Color.black, Color.white));

            }

            return items;
        }

        private Color SetColor(Figure figure)
        {
            if (ChessRools.blackFigures.Contains(figure))
                return Color.red;
            else
                return Color.darckGray;
        }

        private Color SetColor(int i, int j)
        {
            if((i+j)%2 == 1)
            {
                return Color.black;
            }
            return Color.white;
        }

        public override void ReadInput()
        {
            if (status != 2)
            {
                int x = Board.CursoreSelected[1];
                int y = Board.CursoreSelected[0];
            Here: switch (Console.ReadKey(true).Key)
                {
                    #region UpArrow
                    case ConsoleKey.UpArrow:
                        if (Fen.ActiveSide == Color.white)
                        {
                            try
                            {
                                Board.Squares[y - 1, x].CursoreSelected = true;
                                Board.Squares[y, x].CursoreSelected = false;
                                Board.CursoreSelected = new int[2] { y - 1, x };
                            }
                            catch (IndexOutOfRangeException e)
                            {
                                Board.Squares[7, x].CursoreSelected = true;
                                Board.Squares[y, x].CursoreSelected = false;
                                Board.CursoreSelected = new int[2] { 7, x };
                            }
                        }
                        else
                        {
                            try
                            {
                                Board.Squares[y + 1, x].CursoreSelected = true;
                                Board.Squares[y, x].CursoreSelected = false;
                                Board.CursoreSelected = new int[2] { y + 1, x };
                            }
                            catch (IndexOutOfRangeException e)
                            {
                                Board.Squares[0, x].CursoreSelected = true;
                                Board.Squares[y, x].CursoreSelected = false;
                                Board.CursoreSelected = new int[2] { 0, x };
                            }
                        }
                        break;
                    #endregion

                    #region DownArrow
                    case ConsoleKey.DownArrow:
                        if (Fen.ActiveSide == Color.white)
                        {
                            try
                            {
                                Board.Squares[y + 1, x].CursoreSelected = true;
                                Board.Squares[y, x].CursoreSelected = false;
                                Board.CursoreSelected = new int[2] { y + 1, x };
                            }
                            catch (IndexOutOfRangeException e)
                            {
                                Board.Squares[0, x].CursoreSelected = true;
                                Board.Squares[y, x].CursoreSelected = false;
                                Board.CursoreSelected = new int[2] { 0, x };
                            }
                        }
                        else
                        {
                            try
                            {
                                Board.Squares[y - 1, x].CursoreSelected = true;
                                Board.Squares[y, x].CursoreSelected = false;
                                Board.CursoreSelected = new int[2] { y - 1, x };
                            }
                            catch (IndexOutOfRangeException e)
                            {
                                Board.Squares[7, x].CursoreSelected = true;
                                Board.Squares[y, x].CursoreSelected = false;
                                Board.CursoreSelected = new int[2] { 7, x };
                            }
                        }
                        break;
                    #endregion

                    #region LeftArrow
                    case ConsoleKey.LeftArrow:
                        if (Fen.ActiveSide == Color.white)
                        {
                            try
                            {
                                Board.Squares[y, x - 1].CursoreSelected = true;
                                Board.Squares[y, x].CursoreSelected = false;
                                Board.CursoreSelected = new int[2] { y, x - 1 };
                            }
                            catch (IndexOutOfRangeException e)
                            {
                                Board.Squares[y, 7].CursoreSelected = true;
                                Board.Squares[y, x].CursoreSelected = false;
                                Board.CursoreSelected = new int[2] { y, 7 };
                            }
                        }
                        else
                        {
                            try
                            {
                                Board.Squares[y, x + 1].CursoreSelected = true;
                                Board.Squares[y, x].CursoreSelected = false;
                                Board.CursoreSelected = new int[2] { y, x + 1 };
                            }
                            catch (IndexOutOfRangeException e)
                            {

                                Board.Squares[y, 0].CursoreSelected = true;
                                Board.Squares[y, x].CursoreSelected = false;
                                Board.CursoreSelected = new int[2] { y, 0 };
                            }
                        }
                        break;
                    #endregion

                    #region RightArrow
                    case ConsoleKey.RightArrow:
                        if (Fen.ActiveSide == Color.white)
                        {
                            try
                            {
                                Board.Squares[y, x + 1].CursoreSelected = true;
                                Board.Squares[y, x].CursoreSelected = false;
                                Board.CursoreSelected = new int[2] { y, x + 1 };
                            }
                            catch (IndexOutOfRangeException e)
                            {

                                Board.Squares[y, 0].CursoreSelected = true;
                                Board.Squares[y, x].CursoreSelected = false;
                                Board.CursoreSelected = new int[2] { y, 0 };
                            }
                        }
                        else
                        {
                            try
                            {
                                Board.Squares[y, x - 1].CursoreSelected = true;
                                Board.Squares[y, x].CursoreSelected = false;
                                Board.CursoreSelected = new int[2] { y, x - 1 };
                            }
                            catch (IndexOutOfRangeException e)
                            {
                                Board.Squares[y, 7].CursoreSelected = true;
                                Board.Squares[y, x].CursoreSelected = false;
                                Board.CursoreSelected = new int[2] { y, 7 };
                            }
                        }
                        break;
                    #endregion

                    #region Enter

                    case ConsoleKey.Enter:

                        #region White
                        if (Fen.ActiveSide == Color.white /*&& App.Player == BlackPlayer*/)
                        {
                            if (!Board.IsWhiteCheck)
                            {
                                if (!IsSelectedForMove)
                                {
                                    if (ChessRools.whiteFigures.Contains(Board.Squares[y, x].Figure))
                                    {
                                        SelectedForMove = Board.Squares[y, x];
                                        //ChessRools.GetPossibleMove(Board);
                                        IsSelectedForMove = true;

                                        foreach (Square sq in Board.Squares[y, x].FiguresCanMove)
                                        {
                                            sq.MovePossibility = true;
                                        }
                                    }
                                } //Перший вибір
                                else
                                {
                                    if (Board.Squares[Board.CursoreSelected[0], Board.CursoreSelected[1]] == SelectedForMove)
                                    {
                                        foreach (Square sq in Board.Squares)
                                        {
                                            sq.MovePossibility = false;
                                        }
                                        IsSelectedForMove = false;
                                        SelectedForMove = null;
                                    }//Сброс вибору
                                    else
                                    if (Board.Squares[Board.CursoreSelected[0], Board.CursoreSelected[1]].MovePossibility)
                                    {
                                        Board.Squares[Board.CursoreSelected[0], Board.CursoreSelected[1]].Figure = SelectedForMove.Figure;
                                        SelectedForMove.Figure = Figure.none;
                                        foreach (Square sq in Board.Squares)
                                        {
                                            sq.MovePossibility = false;
                                        }
                                        SelectedForMove = null;
                                        IsSelectedForMove = false;
                                        Fen.HalfMoveCount++;
                                        SwapActiveSide();
                                        Update();
                                        #region  Сцена зміни гравця
                                        Console.Clear();
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("Move Black side! Press any key!");
                                        Console.ReadKey(true);
                                        #endregion
                                    }//Хід
                                }
                            }
                            else
                            {
                                if (!IsSelectedForMove)
                                {
                                    if (ChessRools.whiteFigures.Contains(Board.Squares[y, x].Figure))
                                    {
                                        SelectedForMove = Board.Squares[y, x];
                                        //ChessRools.GetPossibleMove(Board);
                                        IsSelectedForMove = true;

                                        foreach (Square sq in Board.Squares[y, x].FiguresCanMove)
                                        {
                                            sq.MovePossibility = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (Board.Squares[Board.CursoreSelected[0], Board.CursoreSelected[1]] == SelectedForMove)
                                    {
                                        foreach (Square sq in Board.Squares)
                                        {
                                            sq.MovePossibility = false;
                                        }
                                        IsSelectedForMove = false;
                                        SelectedForMove = null;
                                    }
                                    else
                                    if (Board.Squares[Board.CursoreSelected[0], Board.CursoreSelected[1]].MovePossibility)
                                    {

                                        Board.Squares[Board.CursoreSelected[0], Board.CursoreSelected[1]].Figure = SelectedForMove.Figure;
                                        SelectedForMove.Figure = Figure.none;


                                        foreach (Square sq in Board.Squares)
                                        {
                                            sq.MovePossibility = false;
                                        }
                                        SelectedForMove = null;
                                        IsSelectedForMove = false;
                                        Board.IsWhiteCheck = false;
                                        Board.WhiteCheckVector = new List<Square[]>();
                                        Board.IsMoveUnderWhiteCheck = 0;

                                        Fen.HalfMoveCount++;
                                        SwapActiveSide();
                                        Update();


                                        #region  Сцена зміни гравця
                                        Console.Clear();
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("Move Black side! Press any key!");
                                        Console.ReadKey(true);
                                        #endregion
                                    }
                                }
                            }
                        }
                        #endregion

                        #region Black
                        else if (Fen.ActiveSide == Color.black /*&& App.Player == BalckPlayer*/)
                        {
                            if (!Board.IsBlackCheck)
                            {
                                if (!IsSelectedForMove)
                                {
                                    if (ChessRools.blackFigures.Contains(Board.Squares[y, x].Figure))
                                    {
                                        SelectedForMove = Board.Squares[y, x];
                                        //ChessRools.GetPossibleMove(Board);
                                        IsSelectedForMove = true;

                                        foreach (Square sq in Board.Squares[y, x].FiguresCanMove)
                                        {
                                            sq.MovePossibility = true;
                                        }
                                    }
                                }//Перший вибір
                                else
                                {
                                    if (Board.Squares[Board.CursoreSelected[0], Board.CursoreSelected[1]] == SelectedForMove)
                                    {
                                        foreach (Square sq in Board.Squares)
                                        {
                                            sq.MovePossibility = false;
                                        }
                                        IsSelectedForMove = false;
                                        SelectedForMove = null;
                                    }//Сброс вибору
                                    else if (Board.Squares[Board.CursoreSelected[0], Board.CursoreSelected[1]].MovePossibility)
                                    {
                                        Board.Squares[Board.CursoreSelected[0], Board.CursoreSelected[1]].Figure = SelectedForMove.Figure;
                                        SelectedForMove.Figure = Figure.none;
                                        foreach (Square sq in Board.Squares)
                                        {
                                            sq.MovePossibility = false;
                                        }
                                        SelectedForMove = null;
                                        IsSelectedForMove = false;
                                        Fen.HalfMoveCount++;
                                        Fen.MoveCount++;

                                        SwapActiveSide();
                                        Update();
                                        #region  Сцена зміни гравця
                                        Console.Clear();
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("Move White side! Press any key!");
                                        Console.ReadKey(true);
                                        #endregion
                                    }//Хід
                                }
                            }
                            else
                            {
                                if (Board.IsMoveUnderBlackCheck == 1)
                                {
                                    if (!IsSelectedForMove)
                                    {
                                        if (ChessRools.blackFigures.Contains(Board.Squares[y, x].Figure))
                                        {
                                            SelectedForMove = Board.Squares[y, x];
                                            //ChessRools.GetPossibleMove(Board);
                                            IsSelectedForMove = true;

                                            foreach (Square sq in Board.Squares[y, x].FiguresCanMove)
                                            {
                                                sq.MovePossibility = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (Board.Squares[Board.CursoreSelected[0], Board.CursoreSelected[1]] == SelectedForMove)
                                        {
                                            foreach (Square sq in Board.Squares)
                                            {
                                                sq.MovePossibility = false;
                                            }
                                            IsSelectedForMove = false;
                                            SelectedForMove = null;
                                        }//Сброс вибору
                                        else if (Board.Squares[Board.CursoreSelected[0], Board.CursoreSelected[1]].MovePossibility)
                                        {
                                            Board.Squares[Board.CursoreSelected[0], Board.CursoreSelected[1]].Figure = SelectedForMove.Figure;
                                            SelectedForMove.Figure = Figure.none;


                                            foreach (Square sq in Board.Squares)
                                            {
                                                sq.MovePossibility = false;
                                            }
                                            SelectedForMove = null;
                                            IsSelectedForMove = false;
                                            Board.IsBlackCheck = false;
                                            Board.BlackCheckVector = new List<Square[]>();
                                            Board.IsMoveUnderBlackCheck = 0;



                                            Fen.HalfMoveCount++;
                                            Fen.MoveCount++;
                                            SwapActiveSide();
                                            Update();


                                            #region  Сцена зміни гравця
                                            Console.Clear();
                                            Console.BackgroundColor = ConsoleColor.Black;
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Move White side! Press any key!");
                                            Console.ReadKey(true);
                                            #endregion
                                        }//Хід
                                    }
                                }
                                else
                                {

                                }
                            }
                        }
                        #endregion

                        break;
                    #endregion

                    #region Escape
                    case ConsoleKey.Escape:
                        App.SetGamePart(new EscapeMenuGamePart(this));
                        App.SetScene(new EscapeMenuScene());
                        break;
                    #endregion


                    default:
                        goto Here;
                }
            }  
            else
            {
                #region  Сцена кінця гри
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(new string(' ', 35) + "End Game!" + new string(' ', 36));
                Console.ReadKey(true);
                Console.Clear();                
                Console.WriteLine("Move Black side! Press any key!");
                Console.ReadKey(true);
                #endregion
            }

        }

        public void Start(string config="NewGameConfig.json")
        {
                      
        }

        
        public override void Update()
        {
            foreach (Square sq in Board.Squares)
            {
                if(sq.FiguresCanMove.Count!=0)
                sq.FiguresCanMove = new List<Square>();
            }

            Square whiteKing=null, blackKing=null;
            foreach(Square sq in Board.Squares)
            {
                switch(sq.Figure)
                {
                    case Figure.blackKing:
                        blackKing = sq;
                        break;
                    case Figure.whiteKing:
                        whiteKing = sq;
                        break;
                    default:
                        ChessRools.GetPossibleMove(sq, Board);
                        break;
                }
            }
            
            if(Fen.ActiveSide == Color.black)
            {
                try
                {
                    ChessRools.KingBaseMove(whiteKing, Board);
                    ChessRools.GetPossibleMove(blackKing, Board);
                }
                catch(NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            else 
            {
                try
                {
                    ChessRools.KingBaseMove(blackKing, Board);
                    ChessRools.GetPossibleMove(whiteKing, Board);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            if(Board.IsWhiteCheck || Board.IsBlackCheck)
            {
                Board.WhiteCheckVector.Clear();
                Board.BlackCheckVector.Clear();
                foreach (Square sq in Board.Squares)
                {
                    if (sq.FiguresCanMove.Count != 0)
                        sq.FiguresCanMove = new List<Square>();
                }

                whiteKing = null; blackKing = null;
                foreach (Square sq in Board.Squares)
                {
                    switch (sq.Figure)
                    {
                        case Figure.blackKing:
                            blackKing = sq;
                            break;
                        case Figure.whiteKing:
                            whiteKing = sq;
                            break;
                        default:
                            ChessRools.GetPossibleMove(sq, Board);
                            break;
                    }
                }

                if (Fen.ActiveSide == Color.black)
                {
                    try
                    {
                        ChessRools.KingBaseMove(whiteKing, Board);
                        ChessRools.GetPossibleMove(blackKing, Board);
                    }
                    catch (NullReferenceException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
                else
                {
                    try
                    {
                        ChessRools.KingBaseMove(blackKing, Board);
                        ChessRools.GetPossibleMove(whiteKing, Board);
                    }
                    catch (NullReferenceException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            if (Board.IsMoveUnderBlackCheck == 2 || Board.IsMoveUnderWhiteCheck == 2)
                status = 2;
        }

        public static void Update( Board Board, Color ActiveSide)
        {
            foreach (Square sq in Board.Squares)
            {
                if (sq.FiguresCanMove.Count != 0)
                    sq.FiguresCanMove = new List<Square>();
            }

            Square whiteKing = null, blackKing = null;
            foreach (Square sq in Board.Squares)
            {
                switch (sq.Figure)
                {
                    case Figure.blackKing:
                        blackKing = sq;
                        break;
                    case Figure.whiteKing:
                        whiteKing = sq;
                        break;
                    default:
                        ChessRools.GetPossibleMove(sq, Board);
                        break;
                }
            }
            if (ActiveSide == Color.black)
            {
                try
                {
                    ChessRools.KingMoveEnded(whiteKing, Board);
                    ChessRools.KingUnderAttack(blackKing, Board);
                    
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            else
            {
                try
                {
                    ChessRools.KingMoveEnded(blackKing, Board);
                    ChessRools.KingUnderAttack(whiteKing, Board);
                    
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}