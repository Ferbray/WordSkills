using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ZMQP.Classes
{
    public class FriendsContext : DbContext
    {
        public FriendsContext() : base("DbContext") { }
        public DbSet<Friends> UserFriends { get; set; }
    }
    public class Friends
    {
        [Key] public int IDUnion { get; set; }
        public int UserID { get; set; }
        public string SecondUserId { get; set; }
    }
}
