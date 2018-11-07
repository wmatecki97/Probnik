using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Probnik.Core.Repositories;

namespace Probnik.Presistence.Repositories
{
    class ChallangeTypeRepository : Repository<ChallangeType>, IChallangeTypeRepository
    {
        public ChallangeTypeRepository(ProbnikContext context): base(context)
        {
        }

        public ProbnikContext ProbnikContext
        {
            get
            {
                return Context as ProbnikContext;
            }
        }

        public ICollection<ChallangeType> GetChallangeTypesForMethodology(int methodologyId)
        {
            return ProbnikContext.ChallangeTypes
                .Include(c => c.Methodologies)
                .Where(c => c.Methodologies.Any(m => m.Id == methodologyId))
                .ToList();
        }

        public ChallangeType GetChallangeTypeWithTasks(int challangeTypeId)
        {
            return ProbnikContext.ChallangeTypes.Include(c => c.Tasks).Single(c => c.Id == challangeTypeId);
        }
    }
}
