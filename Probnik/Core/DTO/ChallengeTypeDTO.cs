using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.Core.DTO
{
    public class ChallengeTypeDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public ICollection<Methodology> Methodologies { get; set; }
        public ICollection<TaskContentDTO> Tasks { get; set; }

        public ChallengeTypeDTO()
        {
            Methodologies = new List<Methodology>();
            Tasks = new List<TaskContentDTO>();
        }

        public ChallengeTypeDTO(ChallangeType ct)
        {
            Id = ct.Id;
            Name = ct.Name;
            Methodologies = ct.Methodologies;
            Tasks = new List<TaskContentDTO>();
            foreach (var taskContent in ct.Tasks)
            {
                Tasks.Add(taskContent.ToTaskContentDTO());
            }
        }
    }
}
