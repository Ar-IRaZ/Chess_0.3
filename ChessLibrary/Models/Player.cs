using System.ComponentModel.DataAnnotations;
using System;

namespace ChessLibrary
{
    public class Player
    {
        [Key]
        public string NickName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}