using Core.DTOs.Order;
using Core.Enums;
using Core.Interface.Facade;
using Core.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EreftSytem.Controllers
{
    [Authorize(Roles = $"{UserRoles.Chief},{UserRoles.Barista},{UserRoles.StoreManager}")]
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase
    {
       
        private readonly ILogger<RequestController> _logger;
        private readonly IRequestService _requestService;

        public RequestController(ILogger<RequestController> logger, IRequestService requestService)
        {
            _logger = logger;
            _requestService = requestService;
        }

        
        [HttpGet("getRequest")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> GetRequest(int categoryId, bool isRefill)
        {
            var result = await _requestService.GetRequest(categoryId, isRefill);

            return Ok(result);
        }
        [HttpPost("createRequest")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> CreateRequest([FromBody] CreateRequestViewModel model)
        {
            var result  = await _requestService.CreateRequest(model);

            return Ok(result);
        }

        [HttpPut("updateRequest")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> UpdateRequest([FromBody] UpdateRequestViewModel updateRequestViewModel)
        {
            var result = await _requestService.UpdateRequest(updateRequestViewModel);

            return Ok(result);
        }


    }
}