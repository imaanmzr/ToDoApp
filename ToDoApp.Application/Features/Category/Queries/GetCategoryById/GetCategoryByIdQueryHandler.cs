using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Exceptions;
using ToDoApp.Domain.Contracts.Repositories;

namespace ToDoApp.Application.Features.Category.Queries.GetCategoryById
{
	public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdDto>
	{
		private readonly IMapper mapper;
		private readonly ICategoryRepository categoryRepository;

		public GetCategoryByIdQueryHandler(IMapper mapper,
										   ICategoryRepository categoryRepository)
        {
			this.mapper = mapper;
			this.categoryRepository = categoryRepository;
		}

        public async Task<GetCategoryByIdDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
		{
			var categoryById = await categoryRepository.GetCategoryById(request.Id);

			if (categoryById == null)
			{
				throw new NotFoundException(nameof(Domain.Entities.Category), request.Id);
			}
			var categoryByIdDto = mapper.Map<GetCategoryByIdDto>(categoryById);

			return categoryByIdDto;
		}
	}
}
