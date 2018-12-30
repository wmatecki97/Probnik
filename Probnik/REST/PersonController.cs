using Grapevine;
using Grapevine.Server;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace Probnik.REST
{
    public sealed class PersonController : RESTResource
    {
        [RESTRoute(Method = HttpMethod.PUT, PathInfo = @"^/Add/Person")]
        public void AcceptPut(HttpListenerContext context)
        {
            foreach (string k in context.Request.QueryString)
            {
                Console.WriteLine("{0}: {1}", k, context.Request.QueryString[k]);
            }
            var a = context.Request;
            var b = context.Response;
            var c = context.User;
            var body = new StreamReader(context.Request.InputStream).ReadToEnd();

            var serializer = new JavaScriptSerializer();
            var jsonObject = serializer.Deserialize<Person>(body);
        }

        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"^/Get/Person")]
        public void HandleGetGreetRequest(HttpListenerContext context)
        {
            Console.WriteLine("URL: {0}", context.Request.RawUrl);
            var person = new Person("Wiktor", "Matecki", "99998271625", "2018-01-01");
            SendJsonResponse(context, person);
        }
    }
}
