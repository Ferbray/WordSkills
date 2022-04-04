using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMQPServer.Classes
{
    public class RequestsContext : DbContext
    {
        public RequestsContext()
            : base("DbConnection") { }

        public DbSet<Request> Requests { get; set; }
    }

    public class Request
    {
        [Key] public int IDRequest { get; set; }
        public int IDUser { get; set; }
        public int IDFriend { get; set; }
    }
}
