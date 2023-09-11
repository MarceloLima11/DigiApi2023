using Application.DTOs.User;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("{nickname}")]
        public IActionResult GetToken(string nickname)
        {
            try
            {
                var result = _authService.GenerateToken(nickname);
                return Ok(result);
            }
            catch (Exception err)
            {
                return Unauthorized(err.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDTO user)
        {
            try
            {
                var result = await _authService.Register();
                return Ok(result);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}