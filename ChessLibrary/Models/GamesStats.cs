using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ChessLibrary
{
    public class GamesStats
    {
        [Key]
        public Player Player { get; set; }
        public int CountOfGame { get; set; }
        public int CountWhiteSideGame { get; set; }
        public int CountBlackSideGame { get; set; }
        public int CountVictory { get; set; }
        public int CountWhiteSideVictory { get; set; }
        public int CountBlackSideVictory { get; set; }        
    }
}