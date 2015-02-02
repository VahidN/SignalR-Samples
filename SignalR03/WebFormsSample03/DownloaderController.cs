using System.Threading;
using System.Web.Http;
using WebFormsSample03.Common;

namespace WebFormsSample03
{
    public class DownloadRequest
    {
        public string Url { set; get; }
        public string ConnectionId { set; get; }
    }

    public class DownloaderController : ApiController
    {
        public void Post([FromBody]DownloadRequest data)
        {
            //todo: start downloading the data.Url ....

            ProgressHub.UpdateProgressBar(10, data.ConnectionId);
            Thread.Sleep(2000);

            ProgressHub.UpdateProgressBar(40, data.ConnectionId);
            Thread.Sleep(3000);

            ProgressHub.UpdateProgressBar(64, data.ConnectionId);
            Thread.Sleep(2000);

            ProgressHub.UpdateProgressBar(77, data.ConnectionId);
            Thread.Sleep(2000);

            ProgressHub.UpdateProgressBar(92, data.ConnectionId);
            Thread.Sleep(3000);

            ProgressHub.UpdateProgressBar(99, data.ConnectionId);
            Thread.Sleep(2000);

            ProgressHub.UpdateProgressBar(100, data.ConnectionId);
        }
    }
}