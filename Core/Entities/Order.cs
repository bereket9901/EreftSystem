using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
	public class Order:BaseEntity
	{

        [ForeignKey("User")]
        public int CreatedBy { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("OrderStatus")]
        public int OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }

        public bool ChiefOrderStatus { get; set; }

        public bool BaristaOrderStatus { get; set; }

        public float TotalPrice { get; set; }

        public virtual IList<OrderMenuItem> OrderMenuItems { get; set;}
    }
}