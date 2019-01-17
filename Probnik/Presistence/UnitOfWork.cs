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
            Challanges = new ChallangeRpository(_context);
            ChallangeTypes = new ChallangeTypeRepository(_context);
            Patrons = new PatronRepository(_context);
            People = new PersonRepository(_context);
            Teams = new TeamRepository(_context);
        }

        public IUserRepository Users { get; private set; }
        public IChallangeRepository Challanges { get; private set; }
        public IChallangeTypeRepository ChallangeTypes { get; private set; }
        public IPatronRepository Patrons { get; private set; }
        public IPersonRepository People { get; private set; }
        public ITeamRepository Teams { get; private set; }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
