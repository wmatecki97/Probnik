using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik
{
    public class TaskContent
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int ChallangeTypeId { get; set; }
        public ChallangeType ChallangeType { get; set; }
        public byte TaskNumber { get; set; }

        public TaskContent()
        {
        }
    }
}
