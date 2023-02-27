using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("Item")]
    public class Item : BaseEntity
    {
        public string Name { get; set; }

        public int MeasuringUnitId { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; } = null;
        public virtual Category Catagory { get; set; }

        public int UnitPrice { get; set; }

    }
}
