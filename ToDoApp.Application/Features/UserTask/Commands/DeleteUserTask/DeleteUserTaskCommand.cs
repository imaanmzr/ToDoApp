using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Features.UserTask.Commands.DeleteUserTask
{
	public class DeleteUserTaskCommand : IRequest<Unit>
	{
		public int Id { get; set; }
	}
}
