using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("Status")]
    public class Status : BaseEntity
    {

        public string Name { get; set; }

    }
}