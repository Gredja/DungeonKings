using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DungeonKings.ErrorModel;
using DungeonKings.Models;
using DungeonKings.Services;

namespace DungeonKings.Controllers
{
    /// <summary>
    /// Settings.
    /// </summary>
    public class SettingsController : ApiController
    {
        /// <summary>
        /// Get game & room current versions information.
        /// </summary>
        public Version Get()
        {
            return new Version();
        }

        /// <summary>
        /// Get game status.
        /// </summary>
        [HttpGet]
        [Route("api/Settings/SettingsStatus")]
        public IHttpActionResult SettingsStatus()
        {
            var status = SettingsProcessor.Instance.GetGameProcessingStatus();
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, status));
        }

        /// <summary>
        /// Upload game settings.
        /// </summary>
        [HttpPost]
        [Route("api/Settings/SettingsSubmit")]
        public IHttpActionResult GameSettingsSubmit([FromBody] string[] urls)
        {
            if (urls != null && urls.Any())
            {
                if (SettingsProcessor.Instance.GetGameProcessingStatus().Status == WorkStatus.Idle)
                {
                    SettingsProcessor.Instance.ProcessGameSettings();
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, Constants.StartProcess));
                }

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), "Game Settings is Processed")));

            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), Constants.EmptyUrls)));
        }     
    }
}