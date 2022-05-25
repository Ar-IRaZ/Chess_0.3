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

        public Game(string fen, /*Scene scene,*/ Player whitePlayer, Player blackPlayer)
        {
            status = 0;
            //Scene = scene;
            Fen = new Fen(fen);
            WhitePlayer = whitePlayer;
            BlackPlayer = blackPlayer;
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
                
                for(int i = 0; i < 8; i++)
                {
                    items.Add(new GameSceneItem("   +---+---+---+---+---+---+---+---+\n"));
                    items.Add(new GameSceneItem(' '+ (i+1).ToString()+" |"));
                    for(int j = 0; j < 8; j++)
                    {                        
                        items.Add(new GameSceneItem(new string(' ',1)+(char)Board.Squares[i,j].Figure+" ",Board.Squares[i,j].CursoreSelected));
                        items.Add(new GameSceneItem(new string('|',1)));
                    }
                    items.Add(new GameSceneItem("\n"));                    
                }
                items.Add(new GameSceneItem("   +---+---+---+---+---+---+---+---+\n"));
                items.Add(new GameSceneItem("     A   B   C   D   E   F   G   H\n"));
            }
            else
            {

            }

            return items;
        }

        public void ReadInput()
        {
            if(Fen.ActiveSide == Color.white /*&& App.Player == BlackPlayer*/)
            {
                int x = Board.CursoreSelected[1];
                int y = Board.CursoreSelected[0];
                Here:  switch(Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                        try
                        {
                            Board.Squares[y - 1, x].CursoreSelected = true;
                            Board.Squares[y, x].CursoreSelected = false;
                            Board.CursoreSelected = new int[2] { y - 1 , x };
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Board.Squares[7, x].CursoreSelected = true;
                            Board.Squares[y, x].CursoreSelected = false;
                            Board.CursoreSelected = new int[2] { 7, x };
                        }           
                            break;
                        

                        case ConsoleKey.DownArrow:
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
                        break;

                        case ConsoleKey.LeftArrow:
                        try
                        {
                            Board.Squares[y, x-1].CursoreSelected = true;
                            Board.Squares[y, x].CursoreSelected = false;
                            Board.CursoreSelected = new int[2] { y, x-1};
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Board.Squares[y, 7].CursoreSelected = true;
                            Board.Squares[y, x].CursoreSelected = false;
                            Board.CursoreSelected = new int[2] { y, 7 };
                        }
                        break;

                        case ConsoleKey.RightArrow:
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
                        break;

                        case ConsoleKey.Enter:
                            break;

                        case ConsoleKey.Escape:
                            break;


                        default:
                            goto Here;                    
                    }
            }
            else if(Fen.ActiveSide == Color.white && App.Player == WhitePlayer)
            {
            
            }
        }

        public  void Start(string config="NewGameConfig.json")
        {
                      
        }
    }
}