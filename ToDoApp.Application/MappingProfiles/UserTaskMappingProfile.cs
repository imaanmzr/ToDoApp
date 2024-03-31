using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Features.UserTask.Commands.CreateTask;
using ToDoApp.Application.Features.UserTask.Commands.UpdateUserTask;
using ToDoApp.Application.Features.UserTask.Queries.GetAllUserTasks;
using ToDoApp.Application.Features.UserTask.Queries.GetUserTaskById;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.MappingProfiles
{
	public class UserTaskMappingProfile : Profile
	{
		public UserTaskMappingProfile()
		{
			CreateMap<GetAllUserTasksDto, UserTask>().ReverseMap();
			CreateMap<UserTask, GetUserTaskByIdDto>();
			CreateMap<CreateUserTaskCommand, UserTask>();
			CreateMap<UpdateUserTaskCommand, UserTask>();
		}

	}
}
