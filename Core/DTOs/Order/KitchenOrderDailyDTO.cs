using System;
using System.Collections.Generic;

namespace Core.DTOs.Order
{
    public class KitchenOrderDailyDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime dateTime { get; set; }
        public string CreatedBy { get; set; }
        public float TotalPrice { get; set; }

        public IList<KithenOrderDailyItem> Items { get; set; }
    }

    public class KithenOrderDailyItem    {
        public double Amount { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
