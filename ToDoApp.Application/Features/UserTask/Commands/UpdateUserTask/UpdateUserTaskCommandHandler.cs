using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Contracts.Repositories;

namespace ToDoApp.Application.Features.UserTask.Commands.UpdateUserTask
{
	internal class UpdateUserTaskCommandHandler : IRequestHandler<UpdateUserTaskCommand, Unit>
	{
		private readonly IMapper mapper;
		private readonly IUserTaskRepository userTaskRepository;

		public UpdateUserTaskCommandHandler(IMapper mapper,
										    IUserTaskRepository userTaskRepository)
        {
			this.mapper = mapper;
			this.userTaskRepository = userTaskRepository;
		}
        public async Task<Unit> Handle(UpdateUserTaskCommand request, CancellationToken cancellationToken)
		{

			var userTaskToUpdate= mapper.Map<Domain.Entities.UserTask>(request);

			await userTaskRepository.UpdateAsync(userTaskToUpdate);

			return Unit.Value;
		}
	}
}
