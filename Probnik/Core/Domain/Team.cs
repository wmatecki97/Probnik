using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Person Owner { get; set; }
        public int OwnerId { get; set; }
        public ICollection<Methodology> Methodologies { get; set; }
        public ICollection<Person> Members { get; set; }
        public ICollection<Patron>  Patrons { get; set; }

        public Team()
        {
        }

        public Team(string name, int ownerId, params Methodology[] methodologies)
        {
            Name = name;
            OwnerId = ownerId;
            Methodologies = methodologies.ToList();
        }

    }
}
