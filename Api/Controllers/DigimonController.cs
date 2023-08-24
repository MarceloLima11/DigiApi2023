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

        // [HttpGet]
        // public async Task<IActionResult> GetDigimons()
        // {
        //     try
        //     {
        //         var result = await _digimonService.GetDigimons();
        //         return Ok(result);
        //     }
        //     catch (Exception err)
        //     {
        //         return BadRequest(err.Message);
        //     }
        // }
    }
}