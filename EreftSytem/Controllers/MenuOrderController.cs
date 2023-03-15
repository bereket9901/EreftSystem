using Core.DTOs;
using Core.DTOs.Order;
using Core.Enums;
using Core.Interface.Facade;
using Core.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EreftSytem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [Authorize(Roles = $"{UserRoles.Chief},{UserRoles.Barista}")]
        [HttpGet("getKitchenOrders")]
        [ProducesResponseType(typeof(List<KitchenOrderDTO>), 200)]
        public async Task<IActionResult> GetKitchenOrders()
        {
            var result = await _orderService.GetKithenOrder();
            return Ok(result);
        }

        [Authorize(Roles = UserRoles.Cashier)]
        [HttpPost("createOrder")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderViewModel model)
        {
            var result = await _orderService.CreateOrder(model);

            return Ok(result);
        }

        [Authorize(Roles = $"{UserRoles.Chief},{UserRoles.Barista}")]
        [HttpPut("updateKitchenOrderDelivered")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> UpdateKitchenOrderDelivered([FromBody] int orderId)
        {
            var result = await _orderService.UpdateKitchenOrderDelivered(orderId);
            return Ok(result);
        }

    }
}