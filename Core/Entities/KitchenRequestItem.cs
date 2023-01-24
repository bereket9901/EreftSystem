using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class KitchenRequestItem:BaseEntity
    {
        [ForeignKey("KitchenRequest")]
        public int? KitchenRequestId { get; set; } = null;
        public virtual KitchenRequest KitchenRequest { get; set; }

        [ForeignKey("Item")]
        public int? ItemId { get; set; } = null;
        public virtual Item Item { get; set; }

        public double Amount { get; set; } 
        
    }
}
