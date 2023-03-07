using Core.DTOs;
using Core.Entities;
using Core.Interface.Facade;
using Core.Interface.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Core.Service
{
    public class CategoryService:ICategoryService
    {
        private IUnitOfWork _iuow;
        public CategoryService(IUnitOfWork iuow) { 
            _iuow = iuow;
        }

        public async Task<IList<CategoryDTO>> GetCategories()
        {
            var categoryRepo = _iuow.Repository<Category>();

            var categories = await categoryRepo.All.Include(c => c.Groups).ThenInclude(g => g.MenuItems).ToListAsync();

            var result = categories.Select(c => new CategoryDTO
            {
                Id= c.Id,
                Name = c.Name,
                Groups = c.Groups.Select(g => new GroupDTO
                {
                    Id= g.Id,
                    Name = g.Name,
                    MenuItems = g.MenuItems.Select(m => new MenuItemDTO
                    {
                        Id= m.Id,
                        Name = m.Name,
                        UnitPrice = m.UnitPrice
                    }).ToList(),

                }).ToList(),
            }).ToList();

            return result;
        }

        public async Task<IList<ItemCategoryDTO>> GetInventoryCategories()
        {
            var itemCategoryRepo = _iuow.Repository<ItemCategory>();

            var itemCategories = await itemCategoryRepo.All.ToListAsync();

            var result = itemCategories.Select(c => new ItemCategoryDTO { 
                Id= c.Id,
                Name=c.Name
            }).ToList();
            return result;
        }

        public async Task<IList<ItemWithCategoryDTO>> GetItemWithCategory(int itemCategoryId)
        {
            var itemRepo = _iuow.Repository<ItemWithCategory>();

            var item = await itemRepo.All.Where(i=>i.ItemCategoryId== itemCategoryId).Include(i=>i.Item).ThenInclude(i=>i.MeasuringUnit).ToListAsync();

            var result = item.Select(i=> new ItemWithCategoryDTO
            {
                Id = i.Id,
                Name = i.Item.Name,
                MeasuringUnit=i.Item.MeasuringUnit.Name
       
            }).ToList();
            return result;
        }
    }
}
