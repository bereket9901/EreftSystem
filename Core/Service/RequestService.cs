using Core.DTOs;
using Core.Entities;
using Core.Enums;
using Core.Interface;
using Core.Interface.Facade;
using Core.Interface.IRepository;
using Core.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Service
{
    public class RequestService: IRequestService
    {
        private IUnitOfWork _iuow;
        private readonly IRepository<Request> _requestRepo;
        private IInventoryService _inventoryService;

        public RequestService(IUnitOfWork iuow, IInventoryService inventoryService)
        {
            _iuow = iuow;
            _requestRepo = _iuow.Repository<Request>();
            _inventoryService = inventoryService;
        }

        public async Task<bool> CreateRequest(CreateRequestViewModel request)
        {

            var requestDb = new Request
            {
                CreatedBy = request.CreatedBy,
                CategoryId = request.CategoryId,
                RequestStatusId = (int)RequestStatusEnum.Created,
                RequestItems = request.RequestItems.Select(ri=> new RequestItem { ItemId=ri.ItemId, Amount=ri.Amount}).ToList(),
            };

            await _requestRepo.InsertAsync(requestDb);

            await _iuow.SaveChangesAsync();

            return true;
        }

        public async Task<IList<RequestDTO>> GetRequest(int categoryId)
        {
            var requests = await _requestRepo.All.Where(r => r.CategoryId == categoryId).Include(r => r.RequestStatus).Include(r => r.User).Include(r => r.RequestItems).ThenInclude(ri => ri.Item).ToListAsync();

            var result = requests.Select(r => new RequestDTO
            {
                Id = r.Id,
                CreatedBy =$"{r.User.FirstName} {r.User.LastName}",
                Status = r.RequestStatus.Name,
                dateTime=r.CreateDateTime,
                Items =r.RequestItems.Select(i => new RequestItems {Name = i.Item.Name, Amount = i.Amount}).ToList()
                
            }).OrderByDescending(r=>r.dateTime).ToList();

            return result;
        }

        public async Task<bool> UpdateRequest(UpdateRequestViewModel updateRequestViewModel)
        {
            var request = await _requestRepo.All.Include(r => r.RequestItems).Where(r => r.Id == updateRequestViewModel.RequestId).FirstOrDefaultAsync();

            if (request == null)
            {
                return false;
            }

            if(request.RequestStatusId != (int)RequestStatusEnum.Created || updateRequestViewModel.RequestStatusId == (int)RequestStatusEnum.Created)
            {
                return false;
            }

            request.RequestStatusId = updateRequestViewModel.RequestStatusId;

            _requestRepo.Update(request);

            if (updateRequestViewModel.RequestStatusId == (int)RequestStatusEnum.Approved)
            {
                var updateInventoryViewModel = new UpdateInventoryViewModel
                {
                    CategoryId = request.CategoryId,
                    Items = request.RequestItems.Select(i => new ItemViewModel
                    {
                        ItemId = i.ItemId,
                        Amount = i.Amount
                    }).ToList()
                };

                var result = await _inventoryService.UpdateInventory(updateInventoryViewModel);

                if (!result) {
                    return false;
                }
            }

            await _iuow.SaveChangesAsync();

            return true;
        }
    }
}
