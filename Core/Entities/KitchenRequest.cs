using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("KitchenRequest")]
    public class KitchenRequest:BaseEntity
    {
        public string CreatedBy { get; set; }
    }
}
