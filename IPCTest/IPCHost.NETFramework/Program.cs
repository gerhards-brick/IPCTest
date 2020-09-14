using System;
using System.Globalization;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Cors;

namespace IPCHost.NETFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses. 
            // See http://msdn.microsoft.com/library/system.net.httplistener.aspx 
            // for more information.
            string url = "http://localhost:8080";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
    [HubName("GhettoHub")]
    public class MyHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.Send("Message has been received");
            Console.WriteLine(message);
            Clients.Caller.Changestate();
        }

        public void CurrentTime()
        {
            var library = new SomeMethodLibrary();
            library.PrintOutTime();
        }
    }

    public class SomeMethodLibrary
    {
        public void PrintOutTime()
        {
            var time = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            Console.WriteLine(time);
        }
    }
}

