using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.Core.DTO
{
    public class TaskContentDTO
    {
        public int? Id { get; set; }
        public string Content { get; set; }
        public int ChallangeTypeId { get; set; }
        public byte TaskNumber { get; set; }

        public TaskContentDTO()
        {
            
        }

        public TaskContentDTO(TaskContent tc)
        {
            Id = tc.Id;
            Content = tc.Content;
            ChallangeTypeId = tc.ChallangeTypeId;
            TaskNumber = tc.TaskNumber;
        }
    }
}
