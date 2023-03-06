using Core.DTOs.Inventory;
using Core.Entities;
using Core.Interface.Facade;
using Core.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Service
{
    public class InventoryService :IInventoryService
    {
        private IUnitOfWork _iuow;
        public InventoryService(IUnitOfWork iuow)
        {
            _iuow = iuow;
        }

        public async Task<IList<InventoryDTO>> GetInventory(int categoryId)
        {
            var inventoryRepo = _iuow.Repository<Inventory>();

            var inventory = await inventoryRepo.All.Where(i=>i.ItemCategoryId==categoryId).Include(i=> i.Item).ThenInclude(it=>it.MeasuringUnit).ToListAsync();

            var result = inventory.Select(i=> new InventoryDTO
            {
                Id = i.Id,
                Amount=i.Amount,
                Name=i.Item.Name,
                ItemUnit=i.Item.MeasuringUnit.Name
            } ).ToList(); ;


            return result;
        }
    }
}
