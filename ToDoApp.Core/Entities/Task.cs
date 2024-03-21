using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Core.Entities
{
	public class Task
	{
		public string? Title { get; private set; }
		public string? Description { get; private set; }
		public DateTime CreatedAt { get; private set; }
		public DateTime UpdatedAt { get; private set; }
		public DateTime DueDate { get; private set; }
		public bool IsCompleted { get; private set; }
		public int CategoryId { get; private set; }



		// Navigation properties
		public virtual Category Category { get; set; }

	}
}
