using AdminApi.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccessController : ControllerBase
    {
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

        public AccessController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Welcome");
        }

        [HttpGet("ready")]
        public IActionResult Getready()
        {
            return Ok("I'm Ready");
        }

        [AllowAnonymous]
        [HttpGet("auth")]
        public IActionResult Authenticate()
        {
            var token = _jwtAuthenticationManager.Authenticate();

            if (token is null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
