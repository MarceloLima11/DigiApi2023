using Api.Attributes;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("email")]

    public class EmailController : ControllerBase
    {
        private readonly ISendEmailService _emailService;

        public EmailController(ISendEmailService emailService)
        { _emailService = emailService; }

        [HttpPost("send-confirm")]
        [TokenValidation]
        public async Task<IActionResult> SendConfirmationEmail([FromBody] string email)
        {
            try
            {
                var result = await _emailService.SendConfirmationEmail(email);
                return Ok(result);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }


        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword(string email)
        {
            try
            {
                var result = await _emailService.SendPasswordResetEmail(email);
                return Ok(result);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}