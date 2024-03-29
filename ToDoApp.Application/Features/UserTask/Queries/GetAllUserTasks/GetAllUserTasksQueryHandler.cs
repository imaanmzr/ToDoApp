using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Contracts.Repositories;

namespace ToDoApp.Application.Features.UserTask.Queries.GetAllUserTasks
{
	public class GetAllUserTasksQueryHandler : IRequestHandler<GetAllUserTasksQuery, List<GetAllUserTasksDto>>
	{
		private readonly IMapper mapper;
		private readonly IUserTaskRepository userTaskRepository;

		public GetAllUserTasksQueryHandler(IMapper mapper,
										   IUserTaskRepository userTaskRepository)
        {
			this.mapper = mapper;
			this.userTaskRepository = userTaskRepository;
		}
        public async Task<List<GetAllUserTasksDto>> Handle(GetAllUserTasksQuery request, CancellationToken cancellationToken)
		{
			var userTasks = await userTaskRepository.GetAllAsync();

			var userTaskDto = mapper.Map<List<GetAllUserTasksDto>>(userTasks);

			return userTaskDto;
		}
	}
}
