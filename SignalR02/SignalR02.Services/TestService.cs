
namespace SignalR02.Services
{
    public class TestService : ITestService
    {
        public int GetRecordsCount()
        {
            return 10; // It's just a sample to test IOC's.
        }
    }
}