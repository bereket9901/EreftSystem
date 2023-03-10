using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreateDateTime = DateTime.UtcNow;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime CreateDateTime { get; set; } 

        public DateTime? ModifiedDateTime { get; set; } = null;

    }
}