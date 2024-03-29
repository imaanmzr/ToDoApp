using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Features.UserTask.Commands.UpdateUserTask
{
	public class UpdateUserTaskCommand:IRequest<Unit>
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public DateTime DueDate { get; set; }
		public bool IsCompleted { get; set; }
		public int CategoryId { get; set; }
	}
}
