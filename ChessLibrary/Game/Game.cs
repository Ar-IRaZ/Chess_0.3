using ChessLibrary.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLibrary.Game
{
    public class Game
    {
        private int status;      //0 - Game continue, <0 - Game ended
        //public Scene Scene { get; set; }
        public Fen Fen { get; set; }
        public Player WhitePlayer { get; set; }
        public Player BlackPlayer { get; set; }
        public Board Board { get; set; }
        private bool IsSelectedForMove { get; set; }
        private Square SelectedForMove { get; set; }

        public Game(string fen, /*Scene scene,*/ Player whitePlayer, Player blackPlayer)
        {
            status = 0;
            //Scene = scene;
            Fen = new Fen(fen);
            WhitePlayer = whitePlayer;
            BlackPlayer = blackPlayer;
            IsSelectedForMove = false;
            Board = new Board().CreateBoard(Fen);
        }

        private void SwapActiveSide()
        {
            if (Fen.ActiveSide == Color.black)
                Fen.ActiveSide = Color.white;
            else
                Fen.ActiveSide = Color.black;
        }

        public List<ISceneItem> GetScene()
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
                    items.Add(new GameSceneItem(' '+ (i+1).ToString()+" ", false, false, Color.black, Color.white));
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
        public void ReadInput()
        {
            
                int x = Board.CursoreSelected[1];
                int y = Board.CursoreSelected[0];
                Here:  switch(Console.ReadKey(true).Key)
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
                    }else
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
                        if (!IsSelectedForMove)
                        {
                            if (ChessRools.whiteFigures.Contains(Board.Squares[y, x].Figure))
                            {
                                SelectedForMove = Board.Squares[y, x];
                                //ChessRools.GetPossibleMove(Board);
                                IsSelectedForMove = true;
                                
                                foreach(Square sq in Board.Squares[y,x].FiguresCanMove)
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
                                SwapActiveSide();
                                UpdateBoard();
                                #region  Сцена зміни гравця
                                Console.Clear();
                                Console.WriteLine("Move Black side! Press any key!");
                                Console.ReadKey(true);
                                #endregion
                            }//Хід
                        }
                    }
                    #endregion

                    #region Black
                    else if (Fen.ActiveSide == Color.black /*&& App.Player == BalckPlayer*/)
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
                                SwapActiveSide();
                                UpdateBoard();
                                #region  Сцена зміни гравця
                                Console.Clear();
                                Console.WriteLine("Move White side! Press any key!");
                                Console.ReadKey(true);
                                #endregion
                            }//Хід
                        }
                    }
                    #endregion

                    break;
                    #endregion

                    #region Escape
                    case ConsoleKey.Escape:

                            break;
                    #endregion


                    default:
                            goto Here;                    
                    }
            
            
        }

        public  void Start(string config="NewGameConfig.json")
        {
                      
        }
        public void UpdateBoard()
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
                    ChessRools.GetPossibleMove(whiteKing, Board);
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
                    ChessRools.GetPossibleMove(blackKing, Board);
                    ChessRools.GetPossibleMove(whiteKing, Board);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}