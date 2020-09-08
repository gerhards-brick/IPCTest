using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using IPCHost.NETFramework.WCF;

namespace IPCHost.NETFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        public void CreateHost()
        {
            var endpoint = new Uri("net.pip://localhost/Testpipe");
            var serviceHost = new ServiceHost(typeof(TestService));
            var binding = new NetNamedPipeBinding();

            serviceHost.AddServiceEndpoint(typeof(ITestService), binding, endpoint);
            serviceHost.Open();
        }
    }
}
