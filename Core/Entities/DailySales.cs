using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("DailySales")]
    public class DailySales : BaseEntity
    {
        public float ActualTotalSales { get; set; }

        public float CalculatedTotalSales { get; set; }
    }
}
