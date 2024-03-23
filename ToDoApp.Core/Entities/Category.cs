using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Common;

namespace ToDoApp.Core.Entities
{
	public class Category : BaseEntity
	{

		public string? Name { get; private set; }
		public string? Description { get; private set; }


		// Navigation properties
		public ICollection<Task> Tasks { get; set; } 


	}
}
