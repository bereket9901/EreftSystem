using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Entities
{
    [Table("ItemWithCategory")]
    public class ItemWithCategory:BaseEntity
    {
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        [ForeignKey("ItemCategory")]
        public int ItemCategoryId { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }


    }
}
