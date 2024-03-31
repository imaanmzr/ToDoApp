using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Contracts.Logging;
using ToDoApp.Application.Exceptions;
using ToDoApp.Domain.Contracts.Repositories;

namespace ToDoApp.Application.Features.UserTask.Commands.UpdateUserTask
{
	internal class UpdateUserTaskCommandHandler : IRequestHandler<UpdateUserTaskCommand, Unit>
	{
		private readonly IMapper mapper;
		private readonly IUserTaskRepository userTaskRepository;
		private readonly IAppLogger<UpdateUserTaskCommandHandler> logger;

		public UpdateUserTaskCommandHandler(IMapper mapper,
										    IUserTaskRepository userTaskRepository,
											IAppLogger<UpdateUserTaskCommandHandler> logger)
        {
			this.mapper = mapper;
			this.userTaskRepository = userTaskRepository;
			this.logger = logger;
		}
        public async Task<Unit> Handle(UpdateUserTaskCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateUserTaskCommandValidator(userTaskRepository);
			var validationResult = await validator.ValidateAsync(request, cancellationToken);

			if (validationResult.Errors.Any())
			{
				logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Domain.Entities.UserTask), request.Id);
				throw new BadRequestException("Invalid Task", validationResult);
			}

			var userTaskToUpdate= mapper.Map<Domain.Entities.UserTask>(request);

			await userTaskRepository.UpdateAsync(userTaskToUpdate);

			return Unit.Value;
		}
	}
}
