using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class KitchenRequestItem:BaseEntity
    {
        [ForeignKey("KitchenRequest")]
        public int KitchenRequestId { get; set; } 
        public virtual KitchenRequest KitchenRequest { get; set; }

        /*  [ForeignKey("Item")]
          public int ItemId { get; set; }
          public virtual Item Item { get; set; }

          [ForeignKey("ItemCategory")]
          public int ItemCategoryId { get; set; }
          public virtual ItemCategory ItemCatagory { get; set; }*/


        [ForeignKey("ItemWithCategory")]
        public int ItemWithCategoryId { get; set; }
        public virtual ItemWithCategory ItemWithCategory { get; set; }

        public double Amount { get; set; }
  
        [ForeignKey("RequestStatus")]
        public int RequestStatusId { get; set; }
        public virtual RequestStatus RequestStatus { get; set; }
    }
}
