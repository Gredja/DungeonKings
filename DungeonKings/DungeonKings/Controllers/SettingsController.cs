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
        /// Upload game settings.
        /// </summary>
        [HttpPost]
        [Route("api/Settings/GameSettingsUpload")]
        public IHttpActionResult GameSettingsUpload([FromBody] string[] urls)
        {
            IHttpActionResult result = ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), "Urls are empty")));

            if (urls != null && urls.Any())
            {
                result = SettingsProcessor.Instance.Process(urls, Request);
            }

            return result;
        }

        /// <summary>
        /// Upload room settings.
        /// </summary>
        [HttpPost]
        [Route("api/Settings/RoomSettingsUpload")]
        public IHttpActionResult RoomSettingsUpload([FromBody] string[] urls)
        {
            IHttpActionResult result = ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), "Urls are empty")));

            if (urls != null && urls.Any())
            {
                result = SettingsProcessor.Instance.Process(urls, Request);
            }

            return result;
        }
    }
}