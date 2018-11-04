using System.Collections.Generic;

namespace Probnik
{
    public class Challange
    {
        public int Id { get; set; }
        public Person Owner { get; set; }
        public TaskContent Task { get; set; }
        public string Mission { get; set; }
        public TaskState State { get; set; }
        public ICollection<string> Comments { get; set; }
        public Patron Patron { get; set; }
    }
}
