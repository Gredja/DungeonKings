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

        [HttpGet]
        [Route("api/Settings/GameStatus")]
        public IHttpActionResult GameStatus()
        {
            var status = SettingsProcessor.Instance.GetGameProcessingStatus();
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, status));
        }

        [HttpGet]
        [Route("api/Settings/RoomStatus")]
        public IHttpActionResult RoomStatus()
        {
            var status = SettingsProcessor.Instance.GetRoomProcessingStatus();
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, status));
        }

        /// <summary>
        /// Upload game settings.
        /// </summary>
        [HttpPost]
        [Route("api/Settings/GameSettingsUpload")]
        public IHttpActionResult GameSettingsUpload([FromBody] string[] urls)
        {
            if (urls != null && urls.Any())
            {
                if (SettingsProcessor.Instance.GetGameProcessingStatus().Status == WorkStatus.Idle)
                {
                    SettingsProcessor.Instance.ProcessGameSettings();
                    return Ok();
                }

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), "Game Settings is Processed")));

            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), "Urls are empty")));
        }

        /// <summary>
        /// Upload room settings.
        /// </summary>
        [HttpPost]
        [Route("api/Settings/RoomSettingsUpload")]
        public IHttpActionResult RoomSettingsUpload([FromBody] string[] urls)
        {
            if (urls != null && urls.Any())
            {
                if (SettingsProcessor.Instance.GetRoomProcessingStatus().Status == WorkStatus.Idle)
                {
                    SettingsProcessor.Instance.ProcessRoomSettings();
                    return Ok();
                }

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), "Room Settings is Processed")));
            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), "Urls are empty")));
        }
    }
}