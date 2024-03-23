using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Common;

namespace ToDoApp.Core.Entities
{
	public class User : BaseEntity
	{
		public string? FirstName { get; private set; }
		public string? LastName { get; private set; }
		public string? Email { get; private set; }
		public string PasswordHash { get; private set; }
		public DateTime CreatedAt { get; private set; }
		public DateTime UpdatedAt { get; private set; }


		// Navigation properties
		public ICollection<Task> Tasks { get; set; }

	}
}
