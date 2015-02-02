using System.Threading;
using Microsoft.AspNet.SignalR;
using ThreadTimer = System.Threading.Timer;

namespace SignalR04.Common
{
    public class PerformanceCounterHub : Hub
    {
        private ThreadTimer _threadTimer; //keep it alive   
        private readonly PerformanceCounterProvider _perfService = new PerformanceCounterProvider();

        public PerformanceCounterHub()
        {
            _threadTimer = new ThreadTimer(timerCallback, null, Timeout.Infinite, 1000);
            _threadTimer.Change(dueTime: 1000, period: 2000);
        }

        private void timerCallback(object state)
        {
            var results = _perfService.GetResults();
            this.Clients.All.newCounters(results);
        }        
    }
}