using Core.Entities;
using Core.Interface.Facade;
using Core.Interface.IRepository;
using System.Threading.Tasks;
using System.Linq;
using Core.ViewModel;
using Core.Enums;

namespace Core.Service
{
    public class OrderService:IOrderService
    {
        private IUnitOfWork _iuow;
        public OrderService(IUnitOfWork iuow) { 
            _iuow = iuow;
        }

        public async Task<bool> CreateOrder(CreateOrderViewModel order)
        {

            var orderDb = new Order {

                CreatedBy = order.CreatedBy,
                OrderStatusId = (int)OrderStatusEnum.Created,
                TotalPrice = order.TotalPrice,
                OrderMenuItems = order.OrderMenuItems.Select(om => new OrderMenuItem {  MenuItemId = om.MenuItemId, Amount = om.Amount, Price = om.Price}).ToList()
            };

            var orderRepo = _iuow.Repository<Order>();

            await orderRepo.InsertAsync(orderDb);

            await _iuow.SaveChangesAsync();

            return true;
        }
    }
}
