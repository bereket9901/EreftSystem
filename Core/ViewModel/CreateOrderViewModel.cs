

using System.Collections.Generic;

namespace Core.ViewModel
{
    public class CreateOrderViewModel
    {
        public CreateOrderViewModel()
        {
            OrderMenuItems = new List<OrderMenuItemViewModel>();
        }
        public int CreatedBy { get; set; }
        public float TotalPrice { get; set; }
        public List<OrderMenuItemViewModel> OrderMenuItems { get; set; }

    }

    public class OrderMenuItemViewModel
    { 
        public int MenuItemId { get; set;}
        public float Price { get; set;}
        public int Amount { get; set;}
    }
}
