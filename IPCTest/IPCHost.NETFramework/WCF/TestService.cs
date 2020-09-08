namespace IPCHost.NETFramework.WCF
{
    public class TestService : ITestService
    {
        public string HelloWorldOverPipe(string message)
        {
            return message;
        }
    }
}
