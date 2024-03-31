using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Contracts.Repositories;

namespace ToDoApp.Application.Features.Category.Commands.CreateCategory
{
	public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
	{
		private readonly ICategoryRepository categoryRepository;

		public CreateCategoryCommandValidator(ICategoryRepository categoryRepository)
		{
			RuleFor(p => p.Name)
				.NotEmpty().WithMessage("{PropertyName} cannot be empty")
				.NotNull()
				.MinimumLength(2).WithMessage("{PropertyName} minimum length is 2 characters")
				.MaximumLength(100).WithMessage("{PropertyName} maximum length is 100 characters");

			RuleFor(p => p.Description)
				.MinimumLength(2).WithMessage("{PropertyName} minimum length is 2 characters")
				.MaximumLength(500).WithMessage("{PropertyName} maximum length is 500 characters");

			RuleFor(p => p)
				.MustAsync(IsCategoryUnique)
				.WithMessage("Category already exists");


			this.categoryRepository = categoryRepository;
		}

		private async Task<bool> IsCategoryUnique(CreateCategoryCommand command, CancellationToken token)
		{
			return await categoryRepository.IsCategoryNameExists(command.Name);
		}
	}
}
