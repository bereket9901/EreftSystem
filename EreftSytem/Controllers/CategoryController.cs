using Core.DTOs;
using Core.Interface.Facade;
using Microsoft.AspNetCore.Mvc;

namespace EreftSytem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
       
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet(Name = "GetCategories")]
        [ProducesResponseType(typeof(List<CategoryDTO>), 200)]
        public async Task<IActionResult> GetCategories()
        {
            var result  = await _categoryService.GetCategories();
            return Ok(result);
        }
    }
}