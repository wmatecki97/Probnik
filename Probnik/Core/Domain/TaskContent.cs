using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Probnik.Core.DTO;

namespace Probnik
{
    public class TaskContent
    {
        public int? Id { get; set; }
        public string Content { get; set; }
        public int ChallangeTypeId { get; set; }
        public ChallangeType ChallangeType { get; set; }
        public byte TaskNumber { get; set; }

        public TaskContent()
        {
        }

        public TaskContentDTO ToTaskContentDTO()
        {
            return new TaskContentDTO(this);
        }

//        public TaskContent ToTaskContent()
//        {
//            TaskContent tc = new TaskContent();
//            tc.Id = Id;
//            tc.Content = Content;
//            tc.ChallangeTypeId = ChallangeTypeId;
//            tc.TaskNumber = TaskNumber;
//
//            return tc;
//        }
    }
}
