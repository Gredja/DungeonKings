using System.Net;
using System.Net.Http;
using System.Web.Http;
using DungeonKings.ErrorModel;
using Timer = System.Timers.Timer;

namespace DungeonKings.Services
{
    public sealed class SettingsProcessor : ApiController
    {
        private static SettingsProcessor _instance;
        private static readonly Timer _timer = new Timer(5000);

        public SettingsProcessor()
        {
            _timer.Elapsed += TimerElapsed;
        }

        public static SettingsProcessor Instance => _instance ?? (_instance = new SettingsProcessor());

        public IHttpActionResult Process(string[] urls, HttpRequestMessage request)
        {
            IHttpActionResult result = ResponseMessage(request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), "Process is running")));

            if (!_timer.Enabled)
            {
                _timer.Start();

                result = ResponseMessage(request.CreateResponse(HttpStatusCode.OK, new ErrorBody(HttpStatusCode.OK.ToString(), "Settings are applying")));
            }

            return result;
        }

        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Stop();
        }
    }
}