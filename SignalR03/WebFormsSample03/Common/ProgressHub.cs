using Microsoft.AspNet.SignalR;

namespace WebFormsSample03.Common
{
    public class ProgressHub : Hub
    {
        /// <summary>
        /// اين متد استاتيك تعريف شده تا در برنامه به صورت مستقيم قابل استفاده باشد
        /// يا مي‌شد اصلا اين متد تعريف نشود و از همان دريافت زمينه هاب در كنترلر استفاده گردد
        /// </summary>        
        public static void UpdateProgressBar(int value, string connectionId)
        {
            var ctx = GlobalHost.ConnectionManager.GetHubContext<ProgressHub>();
            ctx.Clients.Client(connectionId).updateProgressBar(value); //فراخواني يك متد در سمت كلاينت
        }
    }
}