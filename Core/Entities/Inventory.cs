using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("Inventory")]
    public class Inventory : BaseEntity
    {

        [ForeignKey("Item")]
        public int ItemId { get; set; } 
        public virtual Item Item { get; set; }

        [ForeignKey("ItemCategory")]
        public int ItemCategoryId { get; set; }
        public virtual ItemCategory ItemCatagory { get; set; }

        public double Amount { get; set; }

    }
}