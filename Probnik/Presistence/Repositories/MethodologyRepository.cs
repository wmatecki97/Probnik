using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Probnik.Core.Repositories;

namespace Probnik.Presistence.Repositories
{
    class MethodologyRepository: Repository<Methodology>, IMethodologyRepository
    {
        public MethodologyRepository(ProbnikContext context) : base(context)
        {

        }
    }
}
