using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
	public class Order:BaseEntity
	{
        public string CreatedBy { get; set; }

        public DateTime CreatedStamp { get; set; }

        [ForeignKey("OrderStatus")]
        public int? OrderStatusId { get; set; } = null;
        public virtual OrderStatus OrderStatus { get; set; }
       

        public int TotalPrice { get; set; }




    }
}