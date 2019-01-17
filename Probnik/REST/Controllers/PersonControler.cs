using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Grapevine;
using Grapevine.Server;
using Probnik.Core.DTO;
using Probnik.Presistence;

namespace Probnik.REST.Controllers
{
    public sealed class PersonControler : RESTResource
    {
        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"^/Get/Person/")]
        public void GetMainPersonForUser(HttpListenerContext context)
        {
            string token = context.Request.RawUrl.Replace("/Get/Person/", "");
            var session = SessionManager.GetSession(token);

            UnitOfWork unit = new UnitOfWork(session.context);
            var user = unit.Users.GetUserWithPeople(session.user.Id.Value);

            var conn = user.People.FirstOrDefault(c => c.ConnectionType == ConnectionType.PersonToOwner);
            var person = unit.People.Get(conn.PersonId);
            var personDTO = person.ToPersonDTO();

            MyResponder.RespondJson(context, personDTO);
        }

        [RESTRoute(Method = HttpMethod.PUT, PathInfo = @"^/Update/Person/")]
        public void UpdatePerson(HttpListenerContext context)
        {
            string token = context.Request.RawUrl.Replace("/Update/Person/", "");


            var session = SessionManager.GetSession(token);

            var personDTO = RESTHelper.GetObject<PersonDTO>(context);


            UnitOfWork unit = new UnitOfWork(session.context);

            if (personDTO.Id != null)
            {
                var person = unit.People.Get(personDTO.Id.Value);
                person.Name = personDTO.Name;
                person.Surname = personDTO.Surname;
                person.PESEL = personDTO.PESEL;
                person.DateOfBirth = personDTO.DateOfBirth;

                unit.Complete();

                MyResponder.RespondJson(context, personDTO);
            }
            else
            {
                var user = session.user;
                var person = personDTO.ToPerson();
                person.OwnerID = user.Id.Value;

                unit.People.Add(person);
                session.context.SaveChanges();
                person = unit.People.Find(p => p.OwnerID == user.Id).FirstOrDefault();


                var connection = new UserToPersonConnection(user.Id.Value, person.Id.Value, ConnectionType.PersonToOwner);

                person.Users.Add(connection);
                user.People.Add(connection);

                unit.Complete();

                personDTO = person.ToPersonDTO();
                MyResponder.RespondJson(context, personDTO);

            }
        }
    }
}
