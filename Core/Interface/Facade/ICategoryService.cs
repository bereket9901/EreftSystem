
using Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interface.Facade
{
    public interface ICategoryService
    {
        Task<IList<CategoryDTO>> GetCategories();
    }
}
