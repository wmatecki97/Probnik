using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Probnik.Core.Repositories;

namespace Probnik.Presistence.Repositories
{
    class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ProbnikContext context) : base(context)
        {
        }

        public User GetUserWithPeople(int userId)
        {
            return ProbnikContext.Users.Include(u => u.People).Where(u => u.Id == userId).FirstOrDefault();

        }

        public ProbnikContext ProbnikContext
        {
            get
            {
                return Context as ProbnikContext;
            }
        }
    }
}

