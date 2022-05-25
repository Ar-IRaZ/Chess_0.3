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
        

        public GameSceneItem(string str, bool cursoreSelected = false)
        {
            CursoreSelected = cursoreSelected;
            Str = str;
        }
    }
}
