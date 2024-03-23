using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Features.Task.Commands.CreateTask
{
	public class CreateTaskCommand : IRequest<int>
	{
		public string Title { get; private set; } = string.Empty;
		public string Description { get; private set; } = string.Empty;
		public DateTime CreatedAt { get; private set; }
		public DateTime UpdatedAt { get; private set; }
		public DateTime DueDate { get; private set; }
		public bool IsCompleted { get; private set; }
		public int CategoryId { get; private set; }
	}
}
