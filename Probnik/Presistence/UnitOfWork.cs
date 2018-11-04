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
        }

        public IUserRepository Users { get; private set; }

        public int Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
