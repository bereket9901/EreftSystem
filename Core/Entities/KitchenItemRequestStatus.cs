using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class KitchenItemRequestStatus:BaseEntity
    {


        [ForeignKey("Status")]
        public int? StatusId { get; set; } = null;
        public virtual Status Status { get; set; }


        [ForeignKey("KitchenRequest")]
        public int? KitchenRequestId { get; set; } = null;
        public virtual KitchenRequest KitchenRequest { get; set; }
     

        public DateTime DateStamp { get; set; }

    }
}
