using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.Core.Repositories
{
    interface IPatronRepository : IRepository<Patron>
    {
        Patron GetPatronWithPerson(int patronId);
    }
}
