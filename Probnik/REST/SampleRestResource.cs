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
    public sealed class SampleRestResource : RESTResource
    {
        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"^/greet$")]
        public void HandleGetGreetRequest(HttpListenerContext context)
        {
            Console.WriteLine("URL: {0}", context.Request.RawUrl);
            var list = new List<string>() { "s1", "s2", "s3" };
            SendJsonResponse(context, list);
            list = new List<string>();
        }

        [RESTRoute(Method = HttpMethod.PUT, PathInfo = @"^/put$")]
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
            var jsonObject = serializer.Deserialize<Building>(body);
        }

        class Building
        {
            public string name { get; set; }
            public string area { get; set; }
        }

        //[RESTRoute]
        //public void HandleAllGetRequests(HttpListenerContext context)
        //{
        //    SendTextResponse(context, "ROOT NODE");
        //}

    }
}
