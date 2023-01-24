using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("CurrentKitchenInventory")]
    public class CurrentKitchenInventory : BaseEntity
    {

        [ForeignKey("Item")]
        public int? ItemId { get; set; } = null;
        public virtual Item Item { get; set; }

        public double Amount { get; set; }

    }
}