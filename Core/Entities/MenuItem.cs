using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class MenuItem : BaseEntity
    {
        public string Name { get; set; }

        public float UnitPrice { get; set; }

        [ForeignKey("Catagory")]
        public int? CatagoryId { get; set; } = null;
        public virtual Catagory Catagory { get; set; }
        



    } 
}