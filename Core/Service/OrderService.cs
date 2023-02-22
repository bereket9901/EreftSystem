using Core.Entities;
using Core.Interface.Facade;
using Core.Interface.IRepository;
using System.Threading.Tasks;
using System.Linq;
using Core.ViewModel;
using Core.Enums;
using Core.DTOs.Order;
using Core.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Core.Service
{
    public class OrderService:IOrderService
    {
        private readonly IUnitOfWork _iuow;
        private readonly IRepository<Order> _orderRepo;
        public OrderService(IUnitOfWork iuow) { 
            _iuow = iuow;
            _orderRepo = _iuow.Repository<Order>();
        }

        public async Task<bool> CreateOrder(CreateOrderViewModel order)
        {

            var orderDb = new Order {

                CreatedBy = order.CreatedBy,
                OrderStatusId = (int)OrderStatusEnum.Created,
                TotalPrice = order.TotalPrice,
                OrderMenuItems = order.OrderMenuItems.Select(om => new OrderMenuItem {  MenuItemId = om.MenuItemId, Amount = om.Amount, Price = om.Price}).ToList()
            };

            await _orderRepo.InsertAsync(orderDb);

            await _iuow.SaveChangesAsync();

            return true;
        }

        public async Task<IList<KitchenOrderDTO>> GetKithenOrder()
        {
            var orders = await _orderRepo.All.Include(o => o.OrderMenuItems).ThenInclude(m => m.MenuItem).Where(o => o.OrderStatusId == (int)OrderStatusEnum.Created).ToListAsync();

            var result = orders.Select(o => new KitchenOrderDTO
            {
                Id = o.Id,
                Items = o.OrderMenuItems.Select(m => new KithenOrderItem
                {
                    Name = m.MenuItem.Name,
                    Amount = m.Amount,
                    IsChiefOrder = m.MenuItem.ChiefMenu
                }).ToList()
            }).ToList();

            return result;
        }
    }
}
