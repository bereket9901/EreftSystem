using Core.DTOs.Inventory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interface.Facade
{
    public interface IInventoryService
    {
        Task<IList<InventoryDTO>> GetInventory(int categoryId);
    }
}
