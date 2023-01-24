using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
	public class OrderMenuItem
	{

        [ForeignKey("Order")]
        public int? OrderId { get; set; } = null;
        public virtual Order Order { get; set; }

        [ForeignKey("MenuItem")]
        public int? MenuItemId { get; set; } = null;
        public virtual MenuItem MenuItem { get; set; }

        public double Amount { get; set; }

        public float Price { get; set; }
    }
}