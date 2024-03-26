using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Features.UserTask.Commands.CreateTask;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.MappingProfiles
{
	public class UserTaskMappingProfile : Profile
	{
		public UserTaskMappingProfile()
		{
			CreateMap<CreateUserTaskCommand, UserTask>();
			



		}

	}
}
