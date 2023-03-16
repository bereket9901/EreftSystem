using Core.DTOs;
using Core.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interface.Facade
{
    public interface IRequestService
    {
        Task<bool> CreateRequest(CreateRequestViewModel request);
        Task<IList<RequestDTO>> GetRequest(int categoryId, bool isRefill);
        Task<bool> UpdateRequest(UpdateRequestViewModel updateRequestViewModel);

    }
}
