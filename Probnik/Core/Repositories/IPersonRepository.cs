using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.Core.Repositories
{
    interface IPersonRepository : IRepository<Person>
    {
        Person GetPersonWithTeams(int personId);
        Person GetPersonWithChallanges(int personId);
        Person GetPersonWithChallangesAndTeams(int personId);
    }
}
