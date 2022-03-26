using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ZMQP.Classes
{
    public class GamesContext: DbContext
    {
        public GamesContext()
            : base("DbConnection")
        { }

        public DbSet<Game> Games { get; set; }
    }

    public class Game
    {
        [Key]public int IDGame { get; set; }

        public string TitleCompany { get; set; }
        public string TitleGame { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string DownloadLink { get; set; }
    }


}
