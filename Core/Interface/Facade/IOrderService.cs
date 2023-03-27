
using Core.DTOs.Order;
using Core.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interface.Facade
{
    public interface IOrderService
    {
        Task<bool> CreateOrder(CreateOrderViewModel order);
        Task<IList<KitchenOrderDTO>> GetKithenOrder(bool kitchen);
        Task<string> UpdateKitchenOrderStatus(UpdateOrderViewModel model);
        Task<IList<KitchenOrderDailyDTO>> GetAllKitchenOrder();
        Task<IList<KitchenOrderDeliveredDTO>> GetDeliveredKitchenOrder();
        Task<bool> CreateDailySales(CreateDailySalesViewModel model);
    }
}
