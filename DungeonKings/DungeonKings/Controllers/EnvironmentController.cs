using System.Net;
using System.Net.Http;
using System.Web.Http;
using DungeonKings.ErrorModel;
using DungeonKings.Models;
using DungeonKings.Services;

namespace DungeonKings.Controllers
{
    /// <summary>
    /// Environments endpoints.
    /// </summary>
    public class EnvironmentController : ApiController
    {
        /// <summary>
        /// Copy environment settings.
        /// </summary>
        [HttpPost]
        [Route("api/Environment/CopyFrom")]
        public IHttpActionResult CopySettings([FromBody]string copyFrom)
        {
            if (!string.IsNullOrEmpty(copyFrom))
            {
                if (SettingsProcessor.Instance.GetEnvironmentProcessingStatus().Status == WorkStatus.Idle)
                {
                    SettingsProcessor.Instance.ProcessEnvironmentSettings();
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, Constants.StartProcess));
                }

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), "Environment Settings is Processed")));
            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), "Empty url")));
        }

        /// <summary>
        /// Get environment status.
        /// </summary>
        [HttpGet]
        [Route("api/Environment/Status")]
        public IHttpActionResult EnvironmentStatus()
        {
            var status = SettingsProcessor.Instance.GetEnvironmentProcessingStatus();
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, status));
        }


        /// <summary>
        /// Get home status.
        /// </summary>
        [HttpGet]
        [Route("api/Home/Status")]
        public IHttpActionResult Status()
        {
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, "Home Status"));
        }
    }
}