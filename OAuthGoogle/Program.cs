using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace OAuthGoogle
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var app = WebApp.Start<Startup>("http://localhost:8090"))
            {
                Process.Start("http://localhost:8090/api");
                Console.WriteLine("Close this window to stop this server");
                Console.ReadLine();
            }
        }
    }
}
