using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalR02.Services;

namespace SignalR02
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        //جهت آزمايش تزريق خودكار وابستگي‌ها
        private readonly ITestService _testService;
        public ChatHub(ITestService testService)
        {
            _testService = testService;
        }

        public void SendMessage(string message)
        {
            var msg = string.Format("{0}:{1}", Context.ConnectionId, message);
            Clients.All.hello(msg);
            Clients.All.hello(string.Format("RecordsCount: {0}", _testService.GetRecordsCount()));

            //اين دو عبارت هر دو يكي هستند
            /*Clients.Caller.hello(msg);
            Clients.Client(Context.ConnectionId).hello(msg);

            Clients.Others.hello(msg);*/

            //Clients.AllExcept(
        }

        public void JoinRoom(string room)
        {
            this.Groups.Add(Context.ConnectionId, room);
        }

        public void SendMessageToRoom(string room, string msg)
        {
            this.Clients.Group(room).newMesssgae(msg);
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            sendMonitorData("OnDisconnected", Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        private void sendMonitorData(string type, string connection)
        {
            //var ctx = GlobalHost.ConnectionManager.GetHubContext<MonitorHub>();
            //ctx.Clients.All.newEvenet(type, connection);
        }
    }
}