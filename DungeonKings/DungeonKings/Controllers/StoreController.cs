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
    public class StoreController : ApiController
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
        /// Get common status.
        /// </summary>
   [HttpGet]
        [Route("api/Store/CommonStatus")]
        public IHttpActionResult CommonStatus()
        {
            var status = SettingsProcessor.Instance.GetCommonProcessingStatus();
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, status));
        }

        /// <summary>
        /// Get sale status.
        /// </summary>
        [HttpGet]
        [Route("api/Store/SaleStatus")]
        public IHttpActionResult SaleStatus()
        {
            var status = SettingsProcessor.Instance.GetSaleProcessingStatus();
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, status));
        }

        /// <summary>
        /// Upload common store.
        /// </summary>
        [Route("api/Store/CommonStoreUpload")]
        public IHttpActionResult GameSettingsUpload([FromBody] string[] urls)
        {
            if (urls != null && urls.Any())
            {
                if (SettingsProcessor.Instance.GetCommonProcessingStatus().Status == WorkStatus.Idle)
                {
                    SettingsProcessor.Instance.ProcessCommonStore();
                    return Ok();
                }

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), "Common Store is Processed")));
            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), Constants.EmptyUrls)));
        }

        /// <summary>
        /// Upload sale store.
        /// </summary>
        [Route("api/Store/SaleStoreUpload")]
        public IHttpActionResult RoomSettingsUpload([FromBody] string[] urls)
        {
            if (urls != null && urls.Any())
            {
                if (SettingsProcessor.Instance.GetSaleProcessingStatus().Status == WorkStatus.Idle)
                {
                    SettingsProcessor.Instance.ProcessSaleStore();
                    return Ok();
                }

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), "Sale Store is Processed")));
            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), Constants.EmptyUrls)));
        }

        /// <summary>
        /// Get settings activity.
        /// </summary>
        [HttpPost]
        [Route("api/Store/SwitchSettings")]
        public IHttpActionResult SwitchStoreSettings(SettingsActivity activity)
        {
            IHttpActionResult result = ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), "Activities are empty")));

            if (activity != null)
            {
                result = ResponseMessage(activity.Common != activity.Sale
                                ? Request.CreateResponse(HttpStatusCode.OK, new ErrorBody(HttpStatusCode.OK.ToString(), "Activities were applied"))
                                : Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), "Invalid activities")));
            }

            return result;
        }
    }
}