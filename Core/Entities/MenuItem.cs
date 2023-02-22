using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class MenuItem : BaseEntity
    {
        public string Name { get; set; }

        public float UnitPrice { get; set; }

        public bool ChiefMenu { get; set; } = true;

        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        
    } 
}