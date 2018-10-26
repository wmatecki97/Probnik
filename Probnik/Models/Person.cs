using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<UserToPersonConnection> Users { get; set; }
        public virtual ICollection<Challange>  Challanges { get; set; }
    }
}
