using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Grapevine;
using Grapevine.Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using Probnik.Core.DTO;

namespace Probnik.REST.Controllers
{
    public sealed class Responder: RESTResource
    {
        public void RespondJson(HttpListenerContext context, Object obj)
        {

            context.Response.Headers.Clear();
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            var str = JsonConvert.SerializeObject(obj);


            context.Response.ContentEncoding = Encoding.UTF8;

            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var length = buffer.Length;

            context.Response.ContentType = ContentType.JSON.ToValue();
            context.Response.ContentLength64 = length;
            context.Response.OutputStream.Write(buffer, 0, length);
            context.Response.OutputStream.Close();
            context.Response.Close();
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
