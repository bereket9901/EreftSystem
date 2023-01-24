using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class KitchenBalanceItem:BaseEntity
    {
        [ForeignKey("KitchenBalance")]
        public int? KitchenBalanceId { get; set; } = null;
        public virtual KitchenBalance KitchenBalance { get; set; }

        public double AmountLeft { get; set; }

        public int ItemId { get; set; } 

    }
}
