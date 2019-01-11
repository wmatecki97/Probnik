using Grapevine;
using Grapevine.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Probnik.Presistence;
using Probnik.Core.DTO;

namespace Probnik.REST.Controllers
{
    public sealed class TeamsController : RESTResource
    {

        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"^/Get/Teams/")]
        public void GetTeamsByMethodology(HttpListenerContext context)
        {
            string[] parameters = context.Request.RawUrl.Replace("/Get/Teams/", "").Split('/');

            string token = parameters[0];
            int methodologyId = int.Parse(parameters[1]);

            var session = SessionManager.GetSession(token);

            var unit = new UnitOfWork(session.context);

            var teams = unit.Teams.Find(t => t.Methodologies.Any(m => m.Id == methodologyId)).ToList();

            var result = new List<TeamDTO>();

            foreach (var team in teams)
            {
                result.Add(team.ToDTO());
            }

            MyResponder.RespondJson(context, result);
        }

        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"^/Get/Methodologies")]
        public void GetAllMethodologies(HttpListenerContext context)
        {
            string token = context.Request.RawUrl.Replace("/Get/Methodologies/", "");
            var session = SessionManager.GetSession(token);

            var methodologies = session.context.Methodologies.ToList();

            MyResponder.RespondJson(context, methodologies);
        }

        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"^/Get/UserTeams/")]
        public void GetUserTeams(HttpListenerContext context)
        {
            string token = context.Request.RawUrl.Replace("/Get/UserTeams/", "");

            var session = SessionManager.GetSession(token);

            var unit = new UnitOfWork(session.context);

            var personId = session.user.People.FirstOrDefault(p => p.ConnectionType == ConnectionType.PersonToOwner).Id;

            var person = unit.People.GetPersonWithTeams(personId);
            var teams = person.Teams.ToList();

            MyResponder.RespondJson(context, teams);
        }
    }
}
