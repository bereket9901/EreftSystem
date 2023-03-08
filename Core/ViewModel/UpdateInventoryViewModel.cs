

using System.Collections.Generic;

namespace Core.ViewModel
{
    public class UpdateInventoryViewModel
    {
        public UpdateInventoryViewModel()
        {
            Items = new List<ItemViewModel>();
        }
        public int CategoryId { get; set; }
        public List<ItemViewModel> Items { get; set; }

    }

    public class ItemViewModel
    { 
        public int ItemId { get; set;}
        public double Amount { get; set;}
    }
}
