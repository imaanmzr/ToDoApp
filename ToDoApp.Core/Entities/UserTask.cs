using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Common;

namespace ToDoApp.Domain.Entities
{
	public class UserTask : BaseEntity
	{
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public DateTime DueDate { get; set; }
		public bool IsCompleted { get; set; }
		public int CategoryId { get; set; }
		public int UserId { get; set; }



		// Navigation properties
		public Category Category { get; set; }
		public User User { get; set; }

		

	}
}
