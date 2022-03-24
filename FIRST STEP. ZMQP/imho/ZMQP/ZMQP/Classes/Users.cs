using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ZMQP.Classes
{
    public class UserContext: DbContext
    {
        public UserContext()
            : base("Users")
        { }

        public DbSet<User> Users { get; set; }
    }
    public class User
    {
        [Key]public int ID { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int isModerator { get; set; }
    }
}
