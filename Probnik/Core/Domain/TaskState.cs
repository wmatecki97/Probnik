using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik
{
//    public class TaskState
//    {
//        public byte? Id { get; set; }
//        public string Name { get; set; }
//
//        public TaskState()
//        {
//        }
//    }

    public enum TaskState: byte
    {
        NotStarted = 0,
        WaitingForAcceptation = 1,
        Comments = 2,
        InProgress = 3,
        Finished = 4
    }
}
