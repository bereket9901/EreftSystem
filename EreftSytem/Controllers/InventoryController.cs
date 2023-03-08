using Core.DTOs;
using Core.DTOs.Inventory;
using Core.Interface.Facade;
using Core.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EreftSytem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
       
        private readonly ILogger<InventoryController> _logger;
        private readonly IInventoryService _inventoryService;

        public InventoryController(ILogger<InventoryController> logger, IInventoryService inventoryService)
        {
            _logger = logger;
            _inventoryService = inventoryService;
        }

        [HttpGet("GetInventory")]
        [ProducesResponseType(typeof(List<InventoryDTO>), 200)]
        public async Task<IActionResult> GetInventory(int categoryId)
        {
            var result  = await _inventoryService.GetInventory(categoryId);
            return Ok(result);
        }

        [HttpPut("updateInventory")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> UpdateInventory(UpdateInventoryViewModel updateInventoryViewModel)
        {
            var result = await _inventoryService.UpdateInventory(updateInventoryViewModel);
            return Ok(result);
        }
    }
}