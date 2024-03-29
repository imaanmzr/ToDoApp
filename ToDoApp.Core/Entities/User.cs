using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Common;

namespace ToDoApp.Domain.Entities
{
	public class User : BaseEntity
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }
		public string PasswordHash { get; set; }



		// Navigation properties
		public ICollection<UserTask> UserTasks { get; set; }

	}
}
