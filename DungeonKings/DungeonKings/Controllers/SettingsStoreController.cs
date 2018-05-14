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
    /// Settings store.
    /// </summary>
    public class SettingsStoreController : ApiController
    {
        /// <summary>
        /// Get game & room current versions information.
        /// </summary>
        /// <returns></returns>
        public Version Get()
        {
            return new Version();
        }

        /// <summary>
        /// Upload game settings.
        /// </summary>
        [Route("api/GameSettingsStoreUpload")]
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
        [Route("api/RoomSettingsStoreUpload")]
        public IHttpActionResult RoomSettingsUpload([FromBody] string[] urls)
        {
            IHttpActionResult result = ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), "Urls are empty")));

            if (urls != null && urls.Any())
            {
                result = SettingsProcessor.Instance.Process(urls, Request);
            }

            return result;

        }

        /// <summary>
        /// Get settings activity.
        /// </summary>
        [HttpPost]
        [Route("api/GetSettingsActivity")]
        public IHttpActionResult GetSettingsActivity(SettingsActivity activity)
        {
            IHttpActionResult result = ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), "Activities are empty")));

            if (activity != null)
            {
                result = ResponseMessage(activity.Common != activity.Sale
                                ? Request.CreateResponse(HttpStatusCode.OK, new ErrorBody(HttpStatusCode.OK.ToString(), "Settings are applying"))
                                : Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), "Invalid activities")));
            }

            return result;
        }
    }
}