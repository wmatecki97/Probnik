using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Probnik.Core.Repositories;

namespace Probnik.Presistence.Repositories
{
    class PatronRepository : Repository<Patron>, IPatronRepository
    {
        public PatronRepository(ProbnikContext context): base(context)
        {
        }

        public ProbnikContext ProbnikContext
        {
            get
            {
                return Context as ProbnikContext;
            }
        }

        public Patron GetPatronWithPerson(int patronId)
        {
            return ProbnikContext.Patrons.Include(p => p.Person).Single(p => p.Id == patronId);
        }
    }
}
