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
        public IEnumerable<byte> Methodologies { get; set; }
        public IEnumerable<int> Members { get; set; }
        public IEnumerable<int> Patrons { get; set; }

        public TeamDTO()
        {
        }

        public TeamDTO(Team team)
        {
            Id = team.Id;
            Name = team.Name;
            OwnerId = team.OwnerId;
            Methodologies = team.Methodologies.Select(m => m.Id);
            Members = team.Members.Select(m => m.Id.Value);
            Patrons = team.Patrons.Select(p => p.Id);
        }
    }
}
