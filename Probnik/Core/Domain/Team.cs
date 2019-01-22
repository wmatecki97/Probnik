using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Probnik.Core.DTO;

namespace Probnik
{
    public class Team
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        private Person owner;
        public Person Owner
        {
            get
            {
                return owner;
            }
            set
            {
                if (value != null)
                {
                    owner = value;
                    OwnerId = value.Id??-1;
                }
            }
        }
        public int OwnerId { get; set; }
        public ICollection<Methodology> Methodologies { get; set; }
        public ICollection<Person> Members { get; set; }
        public ICollection<Patron>  Patrons { get; set; }

        public Team(string name, int ownerId, params Methodology[] methodologies)
        {
            Name = name;
            OwnerId = ownerId;
            Methodologies = methodologies.ToList();
            Patrons = new List<Patron>();
            Members = new List<Person>();
        }

        public Team()
        {
            Methodologies = new List<Methodology>();
            Members = new List<Person>();
            Patrons = new List<Patron>();
        }

        public TeamDTO ToDTO()
        {
            return new TeamDTO(this);
        }
    }
}
