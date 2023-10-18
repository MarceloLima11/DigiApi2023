using Api.Attributes;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs.TamerManagement;

namespace Api.Controllers
{
    [ApiController]
    [Route("seal")]
    public class SealController : ControllerBase
    {
        private readonly ISealService _sealService;

        public SealController(ISealService sealService)
        { _sealService = sealService; }

        [HttpGet]
        public async Task<IActionResult> GetSeals()
        {
            try
            {
                var result = await _sealService.GetSeals();
                return Ok(result);
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }

        [HttpPost]
        [AuthorizeDeveloper]
        public async Task<IActionResult> CreateSeal([FromBody] SealDTO sealDTO)
        {
            try
            {
                var result = await _sealService.CreateSeal(sealDTO);
                return Ok(result);
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }
    }
}