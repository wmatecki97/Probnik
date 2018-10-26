using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik
{
    public class UserToPersonConnection
    {
        public int id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public ConnectionType ConnectionType { get; set; }

    }
}
