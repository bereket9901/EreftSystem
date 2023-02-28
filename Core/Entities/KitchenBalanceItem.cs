using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class KitchenBalanceItem:BaseEntity
    {
        [ForeignKey("KitchenBalance")]
        public int? KitchenBalanceId { get; set; } = null;
        public virtual KitchenBalance KitchenBalance { get; set; }

        public double AmountLeft { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }    
        public virtual Item Item { get; set; } 

    }
}
