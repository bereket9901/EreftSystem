using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("CurrentStoreInventory")]
    public class CurrentStoreInventory : BaseEntity
    {
        [ForeignKey("Item")]
        public int? ItemId { get; set; } = null;
        public virtual Item Item { get; set; }

        public double Amount { get; set; }

    }
}