using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Contracts.Logging;
using ToDoApp.Domain.Contracts.Repositories;

namespace ToDoApp.Application.Features.UserTask.Queries.GetAllUserTasks
{
	public class GetAllUserTasksQueryHandler : IRequestHandler<GetAllUserTasksQuery, List<GetAllUserTasksDto>>
	{
		private readonly IMapper mapper;
		private readonly IUserTaskRepository userTaskRepository;
		private readonly IAppLogger<GetAllUserTasksQueryHandler> logger;

		public GetAllUserTasksQueryHandler(IMapper mapper,
										   IUserTaskRepository userTaskRepository,
										   IAppLogger<GetAllUserTasksQueryHandler> logger)
        {
			this.mapper = mapper;
			this.userTaskRepository = userTaskRepository;
			this.logger = logger;
		}
        public async Task<List<GetAllUserTasksDto>> Handle(GetAllUserTasksQuery request, CancellationToken cancellationToken)
		{
			var userTasks = await userTaskRepository.GetAllAsync();

			var userTaskDto = mapper.Map<List<GetAllUserTasksDto>>(userTasks);

			logger.LogInformation("User Tasks retrieved successfully");

			return userTaskDto;
		}
	}
}
