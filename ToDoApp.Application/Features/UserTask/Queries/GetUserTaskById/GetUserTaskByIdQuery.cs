using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Features.UserTask.Queries.GetUserTaskById
{
	public record GetUserTaskByIdQuery(int id) : IRequest<GetUserTaskByIdDto>;


}
