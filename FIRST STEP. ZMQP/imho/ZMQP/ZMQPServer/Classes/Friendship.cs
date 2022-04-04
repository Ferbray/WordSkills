using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMQPServer.Classes
{
    public class FriendshipContext : DbContext
    {
        public FriendshipContext()
            : base("DbConnection")
        { }

        public DbSet<Friendship> Friendships { get; set; }
    }

    public class Friendship
    {
        [Key] public int IDFriendship { get; set; }
        public int IDUser { get; set; }
        public int IDFriend { get; set; }
    }
}
