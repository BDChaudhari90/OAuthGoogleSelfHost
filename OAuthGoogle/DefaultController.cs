using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OAuthGoogle
{
    [RoutePrefix("api"), Authorize]
    public class DefaultController : ApiController
    {
        [HttpGet, Route("")]
        public IHttpActionResult Get()
        {
            return Ok("Hello, world!");
        }
    }
}
