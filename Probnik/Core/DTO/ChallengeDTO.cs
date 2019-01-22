using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.Core.DTO
{
    public class ChallengeDTO
    {
        public int? Id { get; set; }
        public PersonDTO Owner { get; set; }
        public TaskContentDTO Task { get; set; }
        public int TaskId { get; set; }
        public string Mission { get; set; }
        public TaskState State { get; set; }
        public string Comment { get; set; }
        public PatronDTO Patron { get; set; }

        public ChallengeDTO()
        {
        }

        public ChallengeDTO(Challange c)
        {
            Id = c.Id;
            Owner = c.Owner.ToPersonDTO();
            Task = c.Task.ToTaskContentDTO();
            TaskId = c.TaskId;
            Mission = c.Mission;
            State = c.State;
            Comment = c.Comment;
            if(c.Patron != null)
                Patron = c.Patron.ToPatronDTO();
        }

        public Challange ToChallenge()
        {
            Challange c = new Challange();
            c.Id = Id;
            c.OwnerId = Owner.Id.Value;
            c.TaskId = Task.Id.Value;
            c.Mission = Mission;
            c.State = State;
            if(Patron != null)
                c.PatronId = Patron.Id;
            return c;
        }
    }
}
