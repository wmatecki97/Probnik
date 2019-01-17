using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.Core.DTO
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public List<Methodology> Methodologies { get; set; }
        public List<PersonDTO> Members { get; set; }
        public List<PersonDTO> Patrons { get; set; }

        public TeamDTO()
        {
        }

        public TeamDTO(Team team)
        {
            Id = team.Id.Value;
            Name = team.Name;
            OwnerId = team.OwnerId;
            Methodologies = team.Methodologies.ToList();
            Members = new List<PersonDTO>();
            Members = team.Members.Select(m => m.ToPersonDTO()).ToList();
            Patrons = team.Patrons.Select(p => p.Person.ToPersonDTO()).ToList();
        }
    }
}
