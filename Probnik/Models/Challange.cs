using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Probnik
{
    public class Challange
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public Person Owner { get; set; }
        public TaskContent Task { get; set; }
        public string Mission { get; set; }
        public TaskStates State { get; set; }
        public ICollection<string> Comments { get; set; }
        public int PatronID { get; set; }
        public Patron Patron { get; set; }
    }
}
