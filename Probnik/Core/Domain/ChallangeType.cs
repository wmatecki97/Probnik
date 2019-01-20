using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Probnik.Core.DTO;

namespace Probnik
{
    public class ChallangeType
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public ICollection<Methodology> Methodologies { get; set; }
        public ICollection<TaskContent> Tasks { get; set; }

        public ChallangeType()
        {
            Methodologies = new List<Methodology>();
            Tasks = new List<TaskContent>();
        }

        public ChallengeTypeDTO ToChallengeTypeDTO()
        {
            return new ChallengeTypeDTO(this);
        }
    }
}
