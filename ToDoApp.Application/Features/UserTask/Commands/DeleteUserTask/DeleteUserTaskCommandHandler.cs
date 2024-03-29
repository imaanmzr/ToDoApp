using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Exceptions;
using ToDoApp.Domain.Contracts.Repositories;

namespace ToDoApp.Application.Features.UserTask.Commands.DeleteUserTask
{
	public class DeleteUserTaskCommandHandler : IRequestHandler<DeleteUserTaskCommand, Unit>
	{
		private readonly IUserTaskRepository userTaskRepository;

		public DeleteUserTaskCommandHandler(IUserTaskRepository userTaskRepository)
        {
			this.userTaskRepository = userTaskRepository;
		}
        public async Task<Unit> Handle(DeleteUserTaskCommand request, CancellationToken cancellationToken)
		{
			var userTaskToDelete = await userTaskRepository.GetByIdAsync(request.Id);
			if (userTaskToDelete == null)
			{
				throw new NotFoundException(nameof(Domain.Entities.UserTask), request.Id);
			}
			await userTaskRepository.DeleteAsync(userTaskToDelete);
			return Unit.Value;
		}
	}
}
