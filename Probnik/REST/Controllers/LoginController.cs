using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Grapevine;
using Grapevine.Server;
using Probnik.Core.DTO;


namespace Probnik.REST.Controllers
{
    public sealed class LoginController : RESTResource
    {
        
        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"/Get/User")]
        public void HandleGetGreetRequest(HttpListenerContext context)
        {
            Console.WriteLine("URL: {0}", context.Request.RawUrl);
            var user = new User();
            user.Login = "wm";
            user.Email = "wm@wp.pl";
            user.Id = 1;
            user.IsAdmin = true;
            user.Password = "haslo";
            user.Token = "AbC1@3";

            var userDTO = new UserDTO(user);
            
            MyResponder.RespondJson(context, userDTO);
        }

    }
}
