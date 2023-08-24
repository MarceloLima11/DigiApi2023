using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("tamer")]
    [ApiController]
    public class TamerController : ControllerBase
    {
        protected readonly ITamerService _tamerService;

        public TamerController(ITamerService tamerService)
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTamer(int id)
        {
            try
            {
                var result = await _tamerService.GetTamer(id);
                return Ok(result);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("skill/buff/{id}")]
        public async Task<IActionResult> GetTamerWithSkillAndBuff(int id)
        {
            try
            {
                var result = await _tamerService.GetTamerWithSkillAndBuff(id);
                return Ok(result);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}