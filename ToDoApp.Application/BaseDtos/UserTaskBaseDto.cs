using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.BaseDtos
{
	public class UserTaskBaseDto
	{
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public DateTime DueDate { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }
		public bool IsCompleted { get; set; }
		public int CategoryId { get; set; }

	}
}
