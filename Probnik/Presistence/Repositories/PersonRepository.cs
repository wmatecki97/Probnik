using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Probnik.Core.Repositories;

namespace Probnik.Presistence.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(ProbnikContext context):base(context)
        {
        }

        public ProbnikContext ProbnikContext
        {
            get
            {
                return Context as ProbnikContext;
            }
        }

        public Person GetPersonByPesel(string pesel)
        {
            return ProbnikContext.People
                .SingleOrDefault(p => p.PESEL == pesel);
        }

        public Person GetPersonWithChallanges(int personId)
        {
            return ProbnikContext.People
                .Include(p => p.Challanges)
                .Include(p => p.Challanges)
                .Single(p => p.Id == personId);
        }

        public Person GetPersonWithChallangesAndTeams(int personId)
        {
            return ProbnikContext.People
                .Include(p => p.Challanges)
                .Include(p => p.Teams)
                .Single(p => p.Id == personId);
        }

        public Person GetPersonWithTeams(int personId)
        {
            return ProbnikContext.People.Include(p => p.Teams).Single(p => p.Id == personId);
        }
    }
}
