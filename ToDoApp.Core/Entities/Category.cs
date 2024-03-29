using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Common;

namespace ToDoApp.Domain.Entities
{
	public class Category : BaseEntity
	{

		public string? Name { get; set; }
		public string? Description { get; set; }


		// Navigation properties
		public ICollection<UserTask> UserTasks { get; set; } 


	}
}
