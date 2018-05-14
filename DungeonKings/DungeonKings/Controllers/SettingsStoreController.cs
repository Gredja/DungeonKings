using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using DungeonKings.Models;

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
        public async Task<IHttpActionResult> GameSettingsUpload(GameSettings settings)
        {
            if (settings?.Urls != null && settings.Urls.Any())
            {
                await Task.Delay(5000);
                return Ok("Game settings were uploaded");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Upload room settings.
        /// </summary>
        [Route("api/RoomSettingsStoreUpload")]
        public async Task<IHttpActionResult> RoomSettingsUpload(RoomSettings settings)
        {
            if (settings?.Urls != null && settings.Urls.Any())
            {
                await Task.Delay(5000);
                return Ok("Game settings were uploaded");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Get settings activity.
        /// </summary>
        [HttpPost]
        [Route("api/GetSettingsActivity")]
        public IHttpActionResult GetSettingsActivity(SettingsActivity activity)
        {
            if (activity != null)
            {
                if (activity.Common != activity.Sale)
                {
                    return Ok("Got settings activity");
                }

                return StatusCode(HttpStatusCode.BadRequest);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}