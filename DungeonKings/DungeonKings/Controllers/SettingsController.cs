using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using DungeonKings.Models;

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
        /// <returns></returns>
        public Version Get()
        {
            return new Version();
        }

        /// <summary>
        /// Upload game settings.
        /// </summary>
        [Route("GameSettingsUpload")]
        public async Task<IHttpActionResult> GameSettingsUpload(GameSettings settings)
        {
            if (settings?.Content != null && settings.Content.Any())
            {
                await Task.Delay(5000);

                return Ok("Game settings were uploaded");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Upload room settings.
        /// </summary>
        [Route("RoomSettingsUpload")]
        public async Task<IHttpActionResult> RoomSettingsUpload(RoomSettings settings)
        {
            if (settings?.Content != null && settings.Content.Any())
            {
                await Task.Delay(5000);

                return Ok("Room settings were uploaded");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}