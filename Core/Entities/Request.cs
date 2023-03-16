using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Entities
{
    public class Request: BaseEntity
    {
        [ForeignKey("User")]
        public int CreatedBy { get; set; }

        public virtual User User { get; set; }
               
        [ForeignKey("RequestStatus")]
        public int RequestStatusId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        
        public bool IsRefill { get; set; }

        public virtual ItemCategory Category { get; set; }

        public virtual RequestStatus RequestStatus { get; set; }

        public virtual IList<RequestItem> RequestItems { get; set; }

    }
}
