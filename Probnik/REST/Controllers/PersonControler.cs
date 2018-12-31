using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Grapevine;
using Grapevine.Server;
using Probnik.Presistence;

namespace Probnik.REST.Controllers
{
    public sealed class PersonControler : RESTResource
    {
        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"^/Get/User/")]
        public void GetMainPersonForUser(HttpListenerContext context)
        {
            string token = context.Request.RawUrl.Replace("/Get/User/", "");
            var session = SessionManager.GetSession(token);

            UnitOfWork unit = new UnitOfWork(session.context);
            var user = unit.Users.GetUserWithPeople(session.user.Id);

            var person = user.People.FirstOrDefault(c => c.ConnectionType == ConnectionType.PersonToOwner);

            MyResponder.RespondJson(context, person);
        }
    }
}
