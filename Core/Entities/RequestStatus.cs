using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("RequestStatus")]
    public class RequestStatus : BaseEntity
    {
        public string Name { get; set; }

    }
}