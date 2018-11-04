using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Probnik.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetUserWithPeople(int userId);
    }
}
