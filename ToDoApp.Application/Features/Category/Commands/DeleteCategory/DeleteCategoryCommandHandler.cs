using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Exceptions;
using ToDoApp.Domain.Contracts.Repositories;

namespace ToDoApp.Application.Features.Category.Commands.DeleteCategory
{
	public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
	{
		private readonly ICategoryRepository categoryRepository;

		public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
			this.categoryRepository = categoryRepository;
		}

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
		{
			var categoryToDelete = await categoryRepository.GetByIdAsync(request.Id);
			if (categoryToDelete == null)
			{
				throw new NotFoundException(nameof(Domain.Entities.Category), request.Id);
			}
			await categoryRepository.DeleteAsync(categoryToDelete);
			return Unit.Value;
		}
	}
}
