using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Exceptions;
using ToDoApp.Application.Features.UserTask.Commands.CreateTask;
using ToDoApp.Domain.Contracts.Repositories;

namespace ToDoApp.Application.Features.UserTask.Commands.UpdateUserTask
{
	public class UpdateUserTaskCommandValidator:AbstractValidator<UpdateUserTaskCommand>
	{
		private readonly IUserTaskRepository userTaskRepository;

		public UpdateUserTaskCommandValidator(IUserTaskRepository userTaskRepository)
        {
			RuleFor(p => p.Id)
			.NotNull()
			.MustAsync(UserTaskMustExist);

			RuleFor(p => p.Title)
				.NotEmpty().WithMessage("{PropertyName} cannot be empty")
				.NotNull()
				.MinimumLength(2).WithMessage("{PropertyName} minimum length is 2 characters")
				.MaximumLength(100).WithMessage("{PropertyName} maximum length is 100 characters");

			RuleFor(p => p.Description)
				.MinimumLength(2).WithMessage("{PropertyName} minimum length is 2 characters")
				.MaximumLength(500).WithMessage("{PropertyName} maximum length is 500 characters");

			RuleFor(p => p)
				.MustAsync(IsUserTaskUnique);

			this.userTaskRepository = userTaskRepository;
		}

		private async Task<bool> UserTaskMustExist(int id, CancellationToken token)
		{
			var userTask = await userTaskRepository.GetByIdAsync(id);
			if (userTask == null)
			{
				throw new NotFoundException("Task Not Found", userTask);
			}
			return userTask != null;
		}

		private async Task<bool> IsUserTaskUnique(UpdateUserTaskCommand command, CancellationToken token)
		{
			var userTaskExists = await userTaskRepository.IsUserTaskExists(command.Title);
			if (userTaskExists)
			{
				throw new BadRequestException("Task already exists");
			}
			return true;
		}
	}
}
