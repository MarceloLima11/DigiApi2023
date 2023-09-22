using Application.DTOs.User;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly ISendEmailService _emailService;
        private readonly IUserService _userService;

        public AuthController(IUserService userService,
        ISendEmailService emailService)
        {
            _emailService = emailService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO user)
        {
            try
            {
                var result = await _userService.Login(user);
                return Ok(result);
            }
            catch (Exception err)
            {
                return Unauthorized(err.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDTO user)
        {
            try
            {
                var result = await _userService.Register(user);
                return Ok(result);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost("email/confirm")]
        public async Task<IActionResult> SendConfirmationEmail()
        {
            try
            {
                await _emailService.Confirmation("", "", "");
                return Ok("Email enviado com sucesso.");
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}