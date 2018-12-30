using CommandLine;
using CommandLine.Text;
using Grapevine;
using Grapevine.Client;
using Grapevine.Server;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Probnik.REST
{
    public static class Server
    {
        public static void Start()
        {
            var exitEvent = new ManualResetEvent(false);
            var options = new RestOptions();

            if (CommandLine.Parser.Default.ParseArgumentsStrict(new string[0], options, () => { Environment.Exit(-2); }))
            {
                options.RunAsServer = true;

                if (options.RunAsServer)
                {
                    //
                    // As server
                    //
                    Console.CancelKeyPress += (sender, eventArgs) =>
                    {
                        eventArgs.Cancel = true;
                        exitEvent.Set();
                    };

                    Console.WriteLine("Run server on " + options.Host + ":" + options.Port);
                    Console.WriteLine("Press CTRL+C to terminate server.\n");
                    Console.WriteLine("Host: {0}:{1}", options.Host, options.Port);

                    try
                    {
                        var server = new RESTServer();
                        server.Host = options.Host;
                        server.Port = options.Port;

                        server.Start();

                        exitEvent.WaitOne();
                        server.Stop();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message + "\n" + e.StackTrace);
                    }
                }
            }
        }
    }
}
