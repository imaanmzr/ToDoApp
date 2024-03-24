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
		public string? FirstName { get; private set; }
		public string? LastName { get; private set; }
		public string? Email { get; private set; }
		public string PasswordHash { get; private set; }



		// Navigation properties
		public ICollection<UserTask> Tasks { get; set; }

	}
}
