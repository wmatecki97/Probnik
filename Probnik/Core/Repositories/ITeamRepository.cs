using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.Core.Repositories
{
    interface ITeamRepository : IRepository<Team>
    {
        Team GetTeamWithMethodologies(int teamId);
    }
}
