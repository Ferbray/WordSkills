using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMQPServer.Classes
{
    public class UserContext : DbContext
    {
        public UserContext()
            : base("DbConnection")
        { }

        public DbSet<User> Users { get; set; }
    }
    public class User
    {
        [Key] public int ID { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int isAdmin { get; set; }

        public string Photo { get; set; }

        public string Description { get; set; }

        public int isBan { get; set; }
        public int isMute { get; set; }

        public int status { get; set; }
    }
}
