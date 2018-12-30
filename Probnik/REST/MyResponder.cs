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
    public sealed class Responder: RESTResource
    {
        public void RespondJson(HttpListenerContext context, Object obj)
        {
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            SendJsonResponse(context, obj);
        }

    }

    public static class MyResponder
    {
        public static void RespondJson(HttpListenerContext context, Object obj)
        {
            var responder = new Responder();
            responder.RespondJson(context, obj);
        }
    }
}
