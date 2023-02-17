using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
	public class Group: BaseEntity
	{
        [ForeignKey("Catagory")]
        public int CatagoryId { get; set; }
        public virtual Category Catagory { get; set; }
        public string Name { get; set; }
        public virtual List<MenuItem> MenuItems { get; set; }
	}
}