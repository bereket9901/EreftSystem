using Core.DTOs.Order;
using Core.Interface.Facade;
using Core.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EreftSytem.Controllers
{
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
        public async Task<IActionResult> GetRequest(int categoryId)
        {
            var result = await _requestService.GetRequest(categoryId);

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