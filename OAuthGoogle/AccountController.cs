using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;

namespace OAuthGoogle
{
    [RoutePrefix("account"), AllowAnonymous]
    public class AccountController : ApiController
    {
        [HttpGet, Route("login")]
        public IHttpActionResult Login(string returnUrl)
        {
            var authProps = new AuthenticationProperties
            {
                RedirectUri = returnUrl
            };
            Request.GetOwinContext().Authentication.Challenge(authProps, "Google");
            return StatusCode(HttpStatusCode.Unauthorized);
            //return Ok();
        }

        [HttpGet, Route("logoff")]
        public IHttpActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return Ok();
        }

        [HttpGet, Route("")]
        public IHttpActionResult ExternalLoginCallback(string returnUrl)
        {
            return Ok();
        }
    }
}
