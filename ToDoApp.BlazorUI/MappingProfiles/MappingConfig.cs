using AutoMapper;
using ToDoApp.BlazorUI.Models.UserTasks;
using ToDoApp.BlazorUI.Services.Base;

namespace ToDoApp.BlazorUI.MappingProfiles
{
	public class MappingConfig : Profile
	{
        public MappingConfig()
        {
            CreateMap<GetAllUserTasksDto, UserTaskViewModel>().ReverseMap();
			CreateMap<GetUserTaskByIdDto, UserTaskViewModel>().ReverseMap();
			CreateMap<UserTaskViewModel, CreateUserTaskCommand>().ReverseMap();
			CreateMap<UserTaskViewModel, UpdateUserTaskCommand>().ReverseMap();
		}
	}
}
