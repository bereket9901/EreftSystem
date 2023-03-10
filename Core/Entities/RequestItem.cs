using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class RequestItem: BaseEntity
    {

        [ForeignKey("Item")]
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }

        [ForeignKey("Request")]
        public int RequestId { get; set; }

        public virtual Request Request { get; set; }

        public float Amount { get; set; }

    }
}
