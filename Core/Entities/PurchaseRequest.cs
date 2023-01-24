using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("PurchaseRequest")]
    public class PurchaseRequest : BaseEntity
    {
        public string CreatedBy { get; set; }

    }
}
