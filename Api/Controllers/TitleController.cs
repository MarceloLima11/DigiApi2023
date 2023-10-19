using Api.Attributes;
using Application.DTOs.TamerManagement;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("title")]
    public class TitleController : ControllerBase
    {
        private readonly ITitleService _titleService;

        public TitleController(ITitleService titleService)
        { _titleService = titleService; }


        [HttpGet]
        public async Task<IActionResult> GetTitles()
        {
            try
            {
                var result = await _titleService.GetTitles();
                return Ok(result);
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }

        [HttpPost]
        [TokenValidation]
        public async Task<ActionResult> CreateTitle([FromBody] TitleDTO titleDTO)
        {
            try
            {
                var result = await _titleService.CreateTitle(titleDTO);
                return Ok(result);
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }
    }
}