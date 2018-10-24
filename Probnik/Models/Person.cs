using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik
{
    public class Person
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Team Team { get; set; }
        public int  TeamId { get; set; }
        public Patron Patron { get; set; }
        public int PatronId { get; set; }
        public ICollection<UserToPersonConnection> Users { get; set; }
    }
}
