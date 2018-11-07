using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.Core.Repositories
{
    interface IChallangeTypeRepository : IRepository<ChallangeType>
    {
        ICollection<ChallangeType> GetChallangeTypesForMethodology(int methodologyId);
        ChallangeType GetChallangeTypeWithTasks(int challangeTypeId);
    }
}
