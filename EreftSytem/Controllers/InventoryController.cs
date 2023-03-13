using Core.DTOs.Inventory;
using Core.Enums;
using Core.Interface.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EreftSytem.Controllers
{
    [Authorize(Roles = UserRoles.Chief)]
    [Authorize(Roles = UserRoles.Barista)]
    [Authorize(Roles = UserRoles.StoreManager)]
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

    }
}