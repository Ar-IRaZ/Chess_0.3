using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary.Models
{
    public class GameContext : DbContext
    {
       
            public GameContext()
                : base(@"data source=(localdb)\MSSQLLocalDB;Initial Catalog=ChessStore;Integrated Security=True;")
            { }

            public DbSet<GameModel> Game { get; set; }
    }
}
