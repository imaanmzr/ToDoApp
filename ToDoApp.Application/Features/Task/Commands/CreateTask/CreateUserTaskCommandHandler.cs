using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Contracts.Repositories;

namespace ToDoApp.Application.Features.Task.Commands.CreateTask
{
	public class CreateUserTaskCommandHandler : IRequestHandler<CreateUserTaskCommand, int>
	{
        public CreateUserTaskCommandHandler(IMapper mapper, IUserTaskRepository userTaskRepository)
        {
            
        }

        public Task<int> Handle(CreateUserTaskCommand request, CancellationToken cancellationToken)
		{

			throw new NotImplementedException();
		}
	}
}
