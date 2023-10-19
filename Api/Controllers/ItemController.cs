using Api.Attributes;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs.ItemManagement;

namespace Api.Controllers
{
    [ApiController]
    [Route("item")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        { _itemService = itemService; }

        [HttpPost]
        [TokenValidation]
        public async Task<IActionResult> CreateItem([FromBody] CreateItemDTO itemDTO)
        {
            try
            {
                var result = await _itemService.CreateItem(itemDTO);
                return Ok(result);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}