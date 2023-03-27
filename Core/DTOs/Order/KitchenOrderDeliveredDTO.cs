using System;
using System.Collections.Generic;

namespace Core.DTOs.Order
{
    public class KitchenOrderDeliveredDTO
    {
        public int? Id { get; set; }      
        public string Name { get; set; }
        public double? Amount { get; set; }
        public float? UnitPrice { get; set; }
        public float TotalPrice { get; set; }
    }

    
        
    
}
