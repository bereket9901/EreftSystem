using Core.DTOs.Inventory;
using Core.Entities;
using Core.Enums;
using Core.Interface;
using Core.Interface.Facade;
using Core.Interface.IRepository;
using Core.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Service
{
    public class InventoryService : IInventoryService
    {
        private IUnitOfWork _iuow;
        private readonly IRepository<Inventory> _inventoryRepo;
        public InventoryService(IUnitOfWork iuow)
        {
            _iuow = iuow;
            _inventoryRepo = _iuow.Repository<Inventory>();
        }

        public async Task<IList<InventoryDTO>> GetInventory(int categoryId)
        {


            var inventory = await _inventoryRepo.All.Where(i => i.ItemCategoryId == categoryId).Include(i => i.Item).ThenInclude(it => it.MeasuringUnit).ToListAsync();

            var result = inventory.Select(i => new InventoryDTO
            {
                Id = i.Id,
                Amount = i.Amount,
                Name = i.Item.Name,
                ItemUnit = i.Item.MeasuringUnit.Name
            }).ToList(); ;


            return result;
        }


        public async Task<bool> UpdateInventory(UpdateInventoryViewModel updateinventoryViewModel)
        {

            try
            {
                if (updateinventoryViewModel.CategoryId == (int)ItemCategoryEnum.Chief)
                {
                    await addRemoveInventoryItem(updateinventoryViewModel.Items, (int)ItemCategoryEnum.Store, false);
                    await addRemoveInventoryItem(updateinventoryViewModel.Items, (int)ItemCategoryEnum.Chief, true);
                }
                else if (updateinventoryViewModel.CategoryId == (int)ItemCategoryEnum.Barista)
                {
                    await addRemoveInventoryItem(updateinventoryViewModel.Items, (int)ItemCategoryEnum.Store, false);
                    await addRemoveInventoryItem(updateinventoryViewModel.Items, (int)ItemCategoryEnum.Barista, true);
                }
                else if (updateinventoryViewModel.CategoryId == (int)ItemCategoryEnum.Store)
                {
                    await addRemoveInventoryItem(updateinventoryViewModel.Items, (int)ItemCategoryEnum.Store, true);
                }

                await _iuow.SaveChangesAsync();
            }
            catch (Exception) {
                return false;
            }
            

            return true;
        }

        private async Task<bool> addRemoveInventoryItem(List<ItemViewModel> items, int categoryId, bool add)
        {
            var inventoryItems = await _inventoryRepo.All.Where(inv => inv.ItemCategoryId == categoryId).ToListAsync();

            foreach (var item in items) { 
                var inventoryItem = inventoryItems.FirstOrDefault(inv => inv.ItemId == item.ItemId);

                if (inventoryItem == null && add) {

                    inventoryItem = new Inventory
                    {
                        Amount = 0,
                        ItemId = item.ItemId,
                        ItemCategoryId = categoryId
                    };

                }
                else if (inventoryItem == null || (!add && inventoryItem.Amount < item.Amount))
                {
                    throw new Exception();
                }

                inventoryItem.Amount = add ? inventoryItem.Amount + item.Amount : inventoryItem.Amount - item.Amount;

                await _inventoryRepo.InserOrUpdateAsync(inventoryItem);
            }

            return true;
            
        }
    }

   }
