using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Probnik.Core.Repositories;

namespace Probnik.Presistence.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(ProbnikContext context):base(context)
        {
        }

        public ProbnikContext ProbnikContext
        {
            get
            {
                return Context as ProbnikContext;
            }
        }

        public IEnumerable<Team> FindTeamsWithMembers(Expression<Func<Team,bool>> expression)
        {
            return ProbnikContext.Teams.Where(expression)
                .Include(t => t.Members);
        }

        public Team GetTeamWithMembers(int teamId)
        {
            return ProbnikContext.Teams
                .Include(t => t.Members)
                .Include(t => t.Methodologies)
                .Single(t => t.Id == teamId);
        }

        public Team GetTeamWithMethodologies(int teamId)
        {
            return ProbnikContext.Teams.Include(t => t.Methodologies).Single(t => t.Id == teamId);
        }
    }
}
