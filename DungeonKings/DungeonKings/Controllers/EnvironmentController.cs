
using System.Net;
using System.Web.Http;

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
        public IHttpActionResult Post(string fromName, string toName)
        {
            if (!string.IsNullOrEmpty(fromName) && !string.IsNullOrEmpty(toName))
            {
                return Ok("Settings were copied");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}