using System.Collections.Generic;
using Probnik.Core.DTO;

namespace Probnik
{
    public class Challange
    {
        public int? Id { get; set; }
        public Person Owner { get; set; }
        public int OwnerId { get; set; }
        public TaskContent Task { get; set; }
        public int TaskId { get; set; }
        public string Mission { get; set; }
        public TaskState State { get; set; }
        public string Comment { get; set; }
        public Patron Patron { get; set; }
        public int? PatronId { get; set; }

        public Challange()
        {
        }

        public ChallengeDTO ToChallengeDTO()
        {
            return new ChallengeDTO(this);
        }
    }
}
