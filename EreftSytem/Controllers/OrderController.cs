using Core.DTOs;
using Core.DTOs.Order;
using Core.Interface.Facade;
using Core.ViewModel;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost(Name = "createOrder")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderViewModel model)
        {
            var result  = await _orderService.CreateOrder(model);
            return Ok(result);
        }

        [HttpGet(Name = "getKitchenOrders")]
        [ProducesResponseType(typeof(List<KitchenOrderDTO>), 200)]
        public async Task<IActionResult> GetKitchenOrders()
        {
            var result = await _orderService.GetKithenOrder();
            return Ok(result);
        }
    }
}