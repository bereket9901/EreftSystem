using Core.DTOs.Inventory;
using Core.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interface.Facade
{
    public interface IInventoryService
    {
        Task<IList<InventoryDTO>> GetInventory(int categoryId);

        Task<bool> UpdateInventory(UpdateInventoryViewModel updateinventoryViewModel);

        Task<bool> SetInventoryState(UpdateInventoryViewModel updateinventoryViewModel);
    }
}
