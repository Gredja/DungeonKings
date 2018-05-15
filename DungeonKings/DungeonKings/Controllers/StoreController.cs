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
        public Version Get()
        {
            return new Version();
        }

        /// <summary>
        /// Get common status.
        /// </summary>
        [HttpGet]
        [Route("api/Store/CommonStatus")]
        public IHttpActionResult StoreCommonStatus()
        {
            var status = SettingsProcessor.Instance.GetCommonProcessingStatus();
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, status));
        }

        /// <summary>
        /// Get sale status.
        /// </summary>
        [HttpGet]
        [Route("api/Store/SaleStatus")]
        public IHttpActionResult StoreSaleStatus()
        {
            var status = SettingsProcessor.Instance.GetSaleProcessingStatus();
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, status));
        }

        /// <summary>
        /// Upload common store.
        /// </summary>
        [Route("api/Store/CommonSubmit")]
        public IHttpActionResult StoreCommonSubmit([FromBody] string[] urls)
        {
            if (urls != null && urls.Any())
            {
                if (SettingsProcessor.Instance.GetCommonProcessingStatus().Status == WorkStatus.Idle)
                {
                    SettingsProcessor.Instance.ProcessCommonStore();
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, Constants.StartProcess));
                }

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), "Common Store is Processed")));
            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorBody(HttpStatusCode.BadRequest.ToString(), Constants.EmptyUrls)));
        }

        /// <summary>
        /// Upload sale store.
        /// </summary>
        [Route("api/Store/SaleSubmit")]
        public IHttpActionResult StoreSaleSubmit([FromBody] string[] urls)
        {
            if (urls != null && urls.Any())
            {
                if (SettingsProcessor.Instance.GetSaleProcessingStatus().Status == WorkStatus.Idle)
                {
                    SettingsProcessor.Instance.ProcessSaleStore();
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, Constants.StartProcess));
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

        /// <summary>
        /// Get active store settings.
        /// </summary>
        [HttpGet]
        [Route("api/Store/ActiveStoreSettings")]
        public SettingsActivity ActiveStoreSettings()
        {
            return new SettingsActivity()
            {
                Common = false,
                Sale = true
            };
        }
    }
}