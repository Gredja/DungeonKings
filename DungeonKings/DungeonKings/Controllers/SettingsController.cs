using System.Linq;
using System.Net;
using System.Web.Http;
using DungeonKings.Models;
using Version = System.Version;

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
        public IHttpActionResult GameSettingsUpload(GameSettings settings)
        {
            if (settings?.Content != null && settings.Content.Any())
            {
                return Ok("Game settings were upload");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Upload room settings.
        /// </summary>
        [Route("RoomSettingsUpload")]
        public IHttpActionResult RoomSettingsUpload(RoomSettings settings)
        {
            if (settings?.Content != null && settings.Content.Any())
            {
                return Ok("Room settings were upload");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}