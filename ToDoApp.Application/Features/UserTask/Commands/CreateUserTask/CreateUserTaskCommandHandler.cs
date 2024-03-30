using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Exceptions;
using ToDoApp.Domain.Contracts.Repositories;

namespace ToDoApp.Application.Features.UserTask.Commands.CreateTask
{
	public class CreateUserTaskCommandHandler : IRequestHandler<CreateUserTaskCommand, int>
	{
		private readonly IMapper mapper;
		private readonly IUserTaskRepository userTaskRepository;

		public CreateUserTaskCommandHandler(IMapper mapper,
											IUserTaskRepository userTaskRepository)
        {
			this.mapper = mapper;
			this.userTaskRepository = userTaskRepository;
		}

        public async Task<int> Handle(CreateUserTaskCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateUserTaskCommandValidator(userTaskRepository);
			var validationResult = await validator.ValidateAsync(request, cancellationToken);

			if (validationResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Task", validationResult);
			}

			var userTaskToCreate = mapper.Map<Domain.Entities.UserTask>(request);

			await userTaskRepository.CreateAsync(userTaskToCreate);

			return userTaskToCreate.Id;
		}
	}
}
