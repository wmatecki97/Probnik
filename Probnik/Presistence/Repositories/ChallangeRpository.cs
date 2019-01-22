using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Probnik.Core.Repositories;

namespace Probnik.Presistence.Repositories
{
    class ChallangeRpository : Repository<Challange>, IChallangeRepository
    {
        public ChallangeRpository(ProbnikContext context):base(context)
        {
        }

        public ProbnikContext ProbnikContext
        {
            get
            {
                return Context as ProbnikContext;
            }
        }

        public ICollection<Challange> GetChallangeForPersonWithTasksInState(int personId, byte taskState)
        {
            return ProbnikContext.Challanges
                .Include(c => c.Owner)
                .Include(c => c.State)
                .Where(c => c.Owner.Id == personId && c.State.Equals(taskState))
                .ToList();
        }

        public ICollection<Challange> GetChallangesByTask(int taskId)
        {
            return ProbnikContext.Challanges
                .Include(c => c.Task)
                .Where(c => c.TaskId == taskId)
                .ToList();
        }

        public ICollection<Challange> GetPatronChallanges(int patronId)
        {
            return ProbnikContext.Challanges
                .Include(c => c.Patron)
                .Where(c => c.Patron.Id == patronId)
                .ToList();
        }

        public ICollection<Challange> GetPersonChallanges(int personId)
        {
            return ProbnikContext.Challanges
                .Include(c => c.Owner)
                .Where(c => c.Owner.Id == personId)
                .ToList();
        }

        public ICollection<Challange> GetChallengesForPatron(int patronId)
        {
            return ProbnikContext.Challanges
                .Include(c => c.Owner)
                .Include(c => c.Task)
                .Where(c => c.PatronId == patronId)
                .ToList();
        }

        public IEnumerable<Challange> FindFull(Expression<Func<Challange, bool>> predicate)
        {
            return ProbnikContext.Challanges
                .Include(c => c.Owner)
                .Include(c => c.Task)
                .Include(c => c.Patron)
                .Where(predicate)
                .ToList();
        }
    }
}
