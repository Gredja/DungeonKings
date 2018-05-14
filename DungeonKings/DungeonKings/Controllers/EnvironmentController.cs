
using System.Net;
using System.Threading.Tasks;
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
        [Route("api/Environment/CopyFrom")]
        public async Task<IHttpActionResult> CopyFrom([FromBody]string fromEnvBaseurl)
        {
            if (!string.IsNullOrEmpty(fromEnvBaseurl))
            {
                return Ok("Settings were copied");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}