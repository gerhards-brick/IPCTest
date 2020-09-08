using System.ServiceModel;

namespace IPCHost.NETFramework.WCF
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        string HelloWorldOverPipe(string message);
    }
}
