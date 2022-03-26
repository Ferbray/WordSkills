using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ZMQP.Classes
{
    public class FriendshipContext: DbContext
    {
        public FriendshipContext()
            : base("DbConnection") 
         { }

        public DbSet<Friendship> Friendships { get; set; }
    }

    public class Friendship
    {
        [Key]public int IDFriendShip { get; set; }
        public int IDUser { get; set; }
        public int IDFriend { get; set; }
    }
}

