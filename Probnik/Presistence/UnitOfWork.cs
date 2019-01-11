using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Probnik.Core;
using Probnik.Core.Repositories;
using Probnik.Presistence.Repositories;

namespace Probnik.Presistence
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly ProbnikContext _context;

        public UnitOfWork(ProbnikContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            People = new PersonRepository(_context);
            Challenges = new ChallangeRpository(_context);
            Teams = new TeamRepository(_context);
        }

        public IUserRepository Users { get; private set; }
        public IPersonRepository People { get; private set; }
        public IChallangeRepository Challenges { get; private set; }
        public ITeamRepository Teams { get; private set; }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
