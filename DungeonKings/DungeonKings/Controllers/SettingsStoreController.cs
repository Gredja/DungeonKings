using System.Linq;
using System.Net;
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
        [Route("GameSettingsStoreUpload")]
        public IHttpActionResult GameSettingsUpload(GameSettings settings)
        {
            if (settings?.Content != null && settings.Content.Any())
            {
                return Ok("Game settings were uploaded");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Upload room settings.
        /// </summary>
        [Route("RoomSettingsStoreUpload")]
        public IHttpActionResult RoomSettingsUpload(RoomSettings settings)
        {
            if (settings?.Content != null && settings.Content.Any())
            {
                return Ok("Room settings were uploaded");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}