using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("PurchaseRequestStatus")]
    public class PurchaseRequestStatus : BaseEntity

    {
        [ForeignKey("Status")]
        public int? StatusId { get; set; } = null;
        public virtual Status Status { get; set; }

        [ForeignKey("PurchaseRequest")]
        public int? PurchaseRequestId { get; set; } = null;
        public virtual PurchaseRequest PurchaseRequest { get; set; }

        public DateTime DateStamp { get; set; }

    }
}