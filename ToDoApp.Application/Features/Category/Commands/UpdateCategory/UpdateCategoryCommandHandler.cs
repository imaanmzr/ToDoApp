using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Contracts.Logging;
using ToDoApp.Application.Exceptions;
using ToDoApp.Application.Features.UserTask.Commands.UpdateUserTask;
using ToDoApp.Domain.Contracts.Repositories;

namespace ToDoApp.Application.Features.Category.Commands.UpdateCategory
{
	public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
	{
		private readonly IMapper mapper;
		private readonly ICategoryRepository categoryRepository;
		private readonly IAppLogger<UpdateCategoryCommandHandler> logger;

		public UpdateCategoryCommandHandler(IMapper mapper,
											ICategoryRepository categoryRepository,
											IAppLogger<UpdateCategoryCommandHandler> logger)
        {
			this.mapper = mapper;
			this.categoryRepository = categoryRepository;
			this.logger = logger;
		}
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateCategoryCommandValidator(categoryRepository);
			var validationResult = await validator.ValidateAsync(request, cancellationToken);

			if (validationResult.Errors.Any())
			{
				logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Domain.Entities.Category), request.Id);
				throw new BadRequestException("Invalid Category", validationResult);
			}
			var category = await categoryRepository.GetByIdAsync(request.Id);

			mapper.Map(request, category);

			await categoryRepository.UpdateAsync(category);

			return Unit.Value;
		}
	}
}
