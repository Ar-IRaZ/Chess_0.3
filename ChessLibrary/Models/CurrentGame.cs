﻿using ChessLibrary.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLibrary
{
    public class CurrentGame
    {
        public Player WhitePlayer { get; set; }
        public Player BlackPlayer { get; set; }
        public Color ActiveSide { get; set; }
        public int CountOfMove { get; set; }
    }
}