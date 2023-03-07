
using Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interface.Facade
{
    public interface ICategoryService
    {
        Task<IList<CategoryDTO>> GetCategories(); 
        Task<IList<ItemCategoryDTO>> GetInventoryCategories(); 
        Task<IList<ItemWithCategoryDTO>> GetItemWithCategory(int itemCategoryId);
    }
}
