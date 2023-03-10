using System.Collections.Generic;

namespace Core.DTOs.Order
{
    public class KitchenOrderDTO
    {
        public int Id { get; set; }
        public IList<KithenOrderItem> Items { get; set; }
    }

    public class KithenOrderItem {
        public double Amount { get; set; }
        public string Name { get; set; }
        public bool IsChiefOrder { get; set; }
    }
}
