using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("Item")]
    public class Item : BaseEntity
    {
        public string Name { get; set; }

        [ForeignKey("MeasuringUnit")]
        public int MeasuringUnitId { get; set; } 
        public virtual MeasuringUnit MeasuringUnit { get; set; }

        public float UnitPrice { get; set; }

    }
}
