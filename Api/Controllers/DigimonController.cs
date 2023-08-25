using Application.DTOs.DigimonManagement;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("digimon")]
    [ApiController]
    public class DigimonController : ControllerBase
    {
        protected readonly IDigimonService _digimonService;

        public DigimonController(IDigimonService digimonService)
        { _digimonService = digimonService; }

        [HttpGet]
        public async Task<IActionResult> GetDigimons()
        {
            try
            {
                var result = await _digimonService.GetDigimons();
                return Ok(result);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDigimon(int id)
        {
            try
            {
                var result = await _digimonService.GetDigimon(id);
                return Ok(result);
            }
            catch (Exception err)
            {
                return NotFound(err.Message);
            }
        }

        [HttpGet("skill/buff/family/{id}")]
        public async Task<IActionResult> GetDigimonWithSkillBuffAndFamily(int id)
        {
            try
            {
                var result = await _digimonService.GetDigimonWithSkillBuffAndFamily(id);
                return Ok(result);
            }
            catch (Exception err)
            {
                return NotFound(err.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDigimon([FromBody] CreateDigimonDTO digimonDTO)
        {
            try
            {
                var result = await _digimonService.CreateDigimon(digimonDTO);
                return Ok(result);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}