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

namespace ToDoApp.Application.Features.Category.Commands.CreateCategory
{
	public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
	{
		private readonly IMapper mapper;
		private readonly ICategoryRepository categoryRepository;
		private readonly IAppLogger<CreateCategoryCommandHandler> logger;

		public CreateCategoryCommandHandler(IMapper mapper,
											ICategoryRepository categoryRepository,
											IAppLogger<CreateCategoryCommandHandler> logger)
        {
			this.mapper = mapper;
			this.categoryRepository = categoryRepository;
			this.logger = logger;
		}
        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateCategoryCommandValidator(categoryRepository);
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Category", validationResult);
			}

			var categoryToCreate = mapper.Map<Domain.Entities.Category>(request);
			await categoryRepository.CreateAsync(categoryToCreate);

			return categoryToCreate.Id;
		}
	}
}
