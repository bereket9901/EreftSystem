using System;
using System.Collections.Generic;

namespace Core.Entities
{
	public class Category: BaseEntity
	{
		public string Name { get; set; }

		public virtual List<Group> Groups { get; set; }

    }
}