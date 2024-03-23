using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Features.Task.Commands.CreateTask
{
	public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
	{
        public CreateTaskCommandHandler(IMapper mapper, )
        {
            
        }

        public Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
		{

			throw new NotImplementedException();
		}
	}
}
