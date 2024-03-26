using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Contracts.Repositories;

namespace ToDoApp.Application.Features.UserTask.Commands.CreateTask
{
	public class CreateUserTaskCommandValidator : AbstractValidator<CreateUserTaskCommand>
	{
		private readonly IUserTaskRepository userTaskRepository;

		public CreateUserTaskCommandValidator(IUserTaskRepository userTaskRepository)
		{
			RuleFor(p => p.Title)
				.NotEmpty().WithMessage("{PropertyName} cannot be empty")
				.NotNull()
				.MinimumLength(2).WithMessage("{PropertyName} minimum length is 2 characters")
				.MaximumLength(100).WithMessage("{PropertyName} maximum length is 100 characters");
			RuleFor(p => p)
				.MustAsync(IsUserTaskUnique);


			this.userTaskRepository = userTaskRepository;
		}


		private async Task<bool> IsUserTaskUnique(CreateUserTaskCommand command, CancellationToken token)
		{
			return await userTaskRepository.IsUserTaskUnique(command.Title);
		}
	}
}
