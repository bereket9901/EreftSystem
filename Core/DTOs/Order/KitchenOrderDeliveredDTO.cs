using System;
using System.Collections.Generic;

namespace Core.DTOs.Order
{
    public class KitchenOrderDeliveredDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime dateTime { get; set; }
        public string CreatedBy { get; set; }

        public IList<KithenOrderDeliveredItem> Items { get; set; }
    }

    public class KithenOrderDeliveredItem    {
        public double Amount { get; set; }
        public string Name { get; set; }
    }
}
