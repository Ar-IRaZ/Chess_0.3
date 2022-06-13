using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary.Models
{
    public class GameModel
    {
        public int GameModelId {get; set;}
        public string Fen { get; set; }
        public string Name { get; set; }
    }
}
