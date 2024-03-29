using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Exceptions;
using ToDoApp.Domain.Contracts.Repositories;

namespace ToDoApp.Application.Features.UserTask.Queries.GetUserTaskById
{
	internal class GetUserTaskByIdQueryHandler : IRequestHandler<GetUserTaskByIdQuery, GetUserTaskByIdDto>
	{
		private readonly IMapper mapper;
		private readonly IUserTaskRepository userTaskRepository;

		public GetUserTaskByIdQueryHandler(IMapper mapper,
										   IUserTaskRepository userTaskRepository)
        {
			this.mapper = mapper;
			this.userTaskRepository = userTaskRepository;
		}
        public async Task<GetUserTaskByIdDto> Handle(GetUserTaskByIdQuery request, CancellationToken cancellationToken)
		{
			var userTaskById = await userTaskRepository.GetByIdAsync(request.id);

			if (userTaskById == null)
			{
				throw new NotFoundException(nameof(Domain.Entities.UserTask),request.id);
			}

			var userTaskByIdDto = mapper.Map<GetUserTaskByIdDto>(userTaskById);

			return userTaskByIdDto;
		}
	}
}
