using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Features.Category.Commands.CreateCategory;
using ToDoApp.Domain.Contracts.Repositories;

namespace ToDoApp.Application.Features.Category.Commands.UpdateCategory
{
	public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
	{
		private readonly ICategoryRepository categoryRepository;

		public UpdateCategoryCommandValidator(ICategoryRepository categoryRepository)
        {
			RuleFor(p => p.Id)
			.NotNull()
			.MustAsync(CategoryMustExist);

			RuleFor(p => p.Name)
				.NotEmpty().WithMessage("{PropertyName} cannot be empty")
				.NotNull()
				.MinimumLength(2).WithMessage("{PropertyName} minimum length is 2 characters")
				.MaximumLength(100).WithMessage("{PropertyName} maximum length is 100 characters");

			RuleFor(p => p.Description)
				.MinimumLength(2).WithMessage("{PropertyName} minimum length is 2 characters")
				.MaximumLength(500).WithMessage("{PropertyName} maximum length is 500 characters");

			RuleFor(p => p)
				.MustAsync(IsCategoryUnique);

			this.categoryRepository = categoryRepository;
		}

		private async Task<bool> CategoryMustExist(int id, CancellationToken token)
		{
			var category = await categoryRepository.GetByIdAsync(id);
			return category != null;
		}

		private async Task<bool> IsCategoryUnique(UpdateCategoryCommand command, CancellationToken token)
		{
			return await categoryRepository.IsCategoryNameExists(command.Name);
		}
	}
}
