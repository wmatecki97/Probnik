using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Grapevine;
using Grapevine.Server;
using Probnik.Core.DTO;
using Probnik.Presistence.Repositories;


namespace Probnik.REST.Controllers
{
    public sealed class LoginController : RESTResource
    {

        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"/Get/User")]
        public void HandleGetGreetRequest(HttpListenerContext context)
        {
            Console.WriteLine("URL: {0}", context.Request.RawUrl);
            var user = new User();
            user.Login = "wmatecki97";
            user.Email = "wmatecki97@gmail.com";
            user.IsAdmin = true;
            user.Password = "haslotestowe";

            
            var userDTO = new UserDTO(user);

            MyResponder.RespondJson(context, userDTO);
        }

        [RESTRoute(Method = HttpMethod.PUT, PathInfo = @"/Login")]
        public void Login(HttpListenerContext context)
        {
            Console.WriteLine("URL: {0}", context.Request.RawUrl);

            var userDTO = RESTHelper.GetObject<UserDTO>(context);
            Session session = new Session(userDTO.Login, userDTO.Password);

            var respondObject = new UserDTO(session.user);
            MyResponder.RespondJson(context, respondObject);
        }

    }
}
