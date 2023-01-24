using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("PurchaseRequestItem")]
    public class PurchaseRequestItem : BaseEntity
    {
        [ForeignKey("Item")]
        public int? ItemId { get; set; } = null;
        public virtual Item Item { get; set; }

        [ForeignKey("PurchaseRequest")]
        public int? PurchaseReqeustId { get; set; } = null;
        public virtual PurchaseRequest PurchaseRequest { get; set; }

        public double Amount { get; set; }

        public float Price { get; set; }
    }
}
