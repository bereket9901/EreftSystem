using Core.DTOs;
using Core.Enums;
using Core.Interface.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [Authorize(Roles = UserRoles.Cashier)]
        [HttpGet("GetCategories")]
        [ProducesResponseType(typeof(List<CategoryDTO>), 200)]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _categoryService.GetCategories();

            return Ok(result);
        }

       
      
       [Authorize(Roles = $"{UserRoles.Barista},{UserRoles.StoreManager}")]
       [HttpGet("GetInventoryCategories")]
       [ProducesResponseType(typeof(List<ItemCategoryDTO>), 200)]
       public async Task<IActionResult> GetInventoryCategories()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var categoryList = await _categoryService.GetInventoryCategories();

            var result = new List<ItemCategoryDTO>();

            foreach (var category in categoryList)
            {
                if ((category.Id == (int)ItemCategoryEnum.Store || category.Id == (int)ItemCategoryEnum.Staff) 
                    && identity.Claims.Select(c => c.Value).Contains(UserRoles.StoreManager)) { 
                    result.Add(category);
                }

                if ((category.Id == (int)ItemCategoryEnum.Chief)
                    && identity.Claims.Select(c => c.Value).Contains(UserRoles.Chief))
                {
                    result.Add(category);
                }

                if ((category.Id == (int)ItemCategoryEnum.Barista)
                    && identity.Claims.Select(c => c.Value).Contains(UserRoles.Barista))
                {
                    result.Add(category);
                }
            }

            return Ok(result);
        }

       [Authorize(Roles = $"{UserRoles.Barista},{UserRoles.StoreManager}")]
       [HttpGet("GetItemWithCategory")]
       [ProducesResponseType(typeof(List<ItemCategoryDTO>), 200)]
       public async Task<IActionResult> GetItemWithCategory(int itemCategoryId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var result = await _categoryService.GetItemWithCategory(itemCategoryId);
            return Ok(result);
        }

    }
}