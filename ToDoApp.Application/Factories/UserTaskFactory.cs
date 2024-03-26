using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Factories
{
	public class UserTaskFactory : IGenericFactory<UserTask>
	{
		public UserTask CreateNewUserTask(int id, string title, string description, DateTime dueDate, DateTime dateModified, bool isCompleted)
		{
			if (id <= 0)
			{
				throw new ArgumentException("Id must be greater than 0", nameof(id));
			}
			if (string.IsNullOrWhiteSpace(title))
			{
				throw new ArgumentException("Task title cannot be null or empty", nameof(id));
			}
			if (string.IsNullOrWhiteSpace(description))
			{
				throw new ArgumentException("Task description cannot be null or empty", nameof(id));
			}

			return new UserTask
			{
				Id = id,
				Title = title,
				Description = description,
				DueDate = dueDate,
				DateCreated = DateTime.Now,
				DateModified = dateModified,
				IsCompleted = isCompleted
			};

		}
	}
}
