using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCourseManagement_Business.Interfaces;

namespace WebCourseManagement_API.Controllers
{
    [Route("api/oauth")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        private readonly IOAuthService _oauthService;
        public OAuthController(IOAuthService oauthService)
        {
            _oauthService = oauthService;
        }
        [HttpPost("ValidateGoogleToken")]
        public async Task<IActionResult> ValidateGoogleToken(string token)
        {
            return Ok(await _oauthService.ValidateGoogleToken(token));
        }
        
    }
}
