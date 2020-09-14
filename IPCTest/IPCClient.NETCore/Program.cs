using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace IPCClient.NETCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var hubconnection = new HubConnection("http://localhost:8080/signalr", useDefaultUrl: false);
            var hubProxy = hubconnection.CreateHubProxy("GhettoHub");
            hubProxy
                .On<string>("send", answer =>
                    Task.Run(() => ActOnReceivedMessage(answer)));
            try
            {
                hubconnection.Start().Wait();
                Console.WriteLine("Connection successful");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            var message = Console.ReadLine();
            hubProxy.Invoke("Send", message);
            Console.ReadLine();
        private static void ActOnReceivedMessage(string message)
        {
            Console.WriteLine(message);
        }
        }
    }
}
