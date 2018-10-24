using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik
{
    public class ChallangeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Methodology> Methodologies { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
