using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Contracts.Logging;
using ToDoApp.Domain.Contracts.Repositories;

namespace ToDoApp.Application.Features.Category.Queries.GetAllCategories
{
	public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<GetAllCategoriesDto>>
	{
		private readonly IMapper mapper;
		private readonly ICategoryRepository categoryRepository;
		private readonly IAppLogger<GetAllCategoriesQueryHandler> logger;

		public GetAllCategoriesQueryHandler(IMapper mapper,
											ICategoryRepository categoryRepository,
											IAppLogger<GetAllCategoriesQueryHandler> logger)
        {
			this.mapper = mapper;
			this.categoryRepository = categoryRepository;
			this.logger = logger;
		}
        public async Task<List<GetAllCategoriesDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
		{
			var categories = await categoryRepository.GetAllCategories();
			var allCategoriesDto = mapper.Map<List<GetAllCategoriesDto>>(categories);

			logger.LogInformation("Categories retrieved successfully");

			return allCategoriesDto;
		}
	}
}
