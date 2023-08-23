using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("tamer/")]
    public class TamerController : ControllerBase
    {
        protected readonly TamerService _tamerService;

        public TamerController(TamerService tamerService)
        { _tamerService = tamerService; }

        [HttpGet]
        public async Task<IActionResult> GetTamers()
        {
            try
            {
                var result = await _tamerService.GetTamers();
                return Ok(result);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}