using System.Collections.Generic;

namespace Core.ViewModel
{
    public class CreateRequestViewModel
    {
        public CreateRequestViewModel()
        {
            RequestItems = new List<RequestItemViewModel>();
        }

        public int CreatedBy { get; set; }

        public int CategoryId { get; set; }

        public IList<RequestItemViewModel> RequestItems { get; set; }

    }

    public class RequestItemViewModel
    {
        public int ItemId { get; set; }
        public float Amount { get; set; }
    }
}