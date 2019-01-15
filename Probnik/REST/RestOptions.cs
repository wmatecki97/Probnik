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
    class RestOptions
    {
        [Option("server", DefaultValue = false, Required = false, HelpText = "Run as REST server.")]
        public bool RunAsServer { get; set; }

        [Option("host", DefaultValue = "localhost", Required = false, HelpText = "Set host IP.")]
        public string Host { get; set; }

        [Option("port", DefaultValue = "1234", Required = false, HelpText = "Set host port.")]
        public string Port { get; set; }

        [Option("url", DefaultValue = "/", Required = false,
            HelpText = @"URL after [host:port]. Should start with '/'.")]
        public string Url { get; set; }

        [Option("method", DefaultValue = "GET", Required = false, HelpText = "GET, POST.")]
        public string Method { get; set; }

        [Option("timeout", DefaultValue = -1, Required = false,
            HelpText = "Request timeout in milliseconds. When value is -1, client will use " +
                       "the default timeout set in GrapeVine (1.21 seconds).")]
        public int Timeout { get; set; }

        [HelpOption]
        public string GetHelp()
        {
            return HelpText.AutoBuild(this, (HelpText current) =>
                HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
