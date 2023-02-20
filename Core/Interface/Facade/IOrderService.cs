
using Core.ViewModel;
using System.Threading.Tasks;

namespace Core.Interface.Facade
{
    public interface IOrderService
    {
        Task<bool> CreateOrder(CreateOrderViewModel order);
    }
}
