using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.Core.Repositories
{
    interface ITeamRepository : IRepository<Team>
    {
        Team GetTeamWithMethodologies(int teamId);
        Team GetTeamWithMembers(int teamId);
        IEnumerable<Team> FindTeamsWithMembers(Expression<Func<Team, bool>> expression);
    }
}
