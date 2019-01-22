using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.Core.Repositories
{
    interface IChallangeRepository : IRepository<Challange>
    {
        ICollection<Challange> GetPersonChallanges(int personId);
        ICollection<Challange> GetPatronChallanges(int patronId);
        ICollection<Challange> GetChallangesByTask(int taskId);
        ICollection<Challange> GetChallangeForPersonWithTasksInState(int personId, byte taskState);
        ICollection<Challange> GetChallengesForPatron(int patronId);
        IEnumerable<Challange> FindFull(Expression<Func<Challange, bool>> predicate);
    }
}
