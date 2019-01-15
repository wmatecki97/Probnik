using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Probnik.REST
{
    class RESTHelper
    {
        public static T GetObject<T>(HttpListenerContext context)
        {
            var body = new StreamReader(context.Request.InputStream).ReadToEnd();
            var serializer = new JavaScriptSerializer();
            var obj = serializer.Deserialize<T>(body);

            return obj;
        }
    }
}
