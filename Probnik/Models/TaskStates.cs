using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik
{
    public enum TaskStates : byte
    {
        WaitingForAccept = 0,
        InProgress = 1,
        Canceled = 2,
    }
}
