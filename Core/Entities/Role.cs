using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("Role")]
    public class Role : BaseEntity
    {
        public string Name { get; set; }
    }
}