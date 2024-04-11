using AutoMapper;
using Blazored.LocalStorage;
using ToDoApp.BlazorUI.Contracts;
using ToDoApp.BlazorUI.Models.UserTasks;
using ToDoApp.BlazorUI.Services.Base;

namespace ToDoApp.BlazorUI.Services
{
	public class UserTaskService : BaseHttpService, IUserTaskService
	{
		private readonly IMapper mapper;

		public UserTaskService(IClient client,
							   IMapper mapper,
							   ILocalStorageService localStorageService) : base(client, localStorageService)
		{
			this.mapper = mapper;
		}

		public async Task<Response<Guid>> CreateUserTask(UserTaskViewModel userTask)
		{
			try
			{
				await AddBearerToken();
				var createUserTaskCommand = mapper.Map<CreateUserTaskCommand>(userTask);
				await _client.UserTasksPOSTAsync(createUserTaskCommand);
				return new Response<Guid>()
				{
					Success = true
				};
			}
			catch (ApiException ex)
			{
				return convertApiExceptions<Guid>(ex);
			}
		}

		public async Task<Response<Guid>> DeleteUserTask(int id)
		{
			try
			{
				await AddBearerToken();
				await _client.UserTasksDELETEAsync(id);
				return new Response<Guid>()
				{
					Success = true
				};
			}
			catch (ApiException ex)
			{
				return convertApiExceptions<Guid>(ex);
			}
		}

		public async Task<List<UserTaskViewModel>> GetAllUserTasks()
		{
			await AddBearerToken();
			var userTasks = await _client.UserTasksAllAsync();

			return mapper.Map<List<UserTaskViewModel>>(userTasks);
		}

		public async Task<UserTaskViewModel> GetUserTaskById(int id)
		{
			await AddBearerToken();
			var userTask = await _client.UserTasksGETAsync(id);

			return mapper.Map<UserTaskViewModel>(userTask);
		}

		public async Task<Response<Guid>> UpdateUserTask(int id, UserTaskViewModel userTask)
		{
			try
			{
				await AddBearerToken();
				var updateUserTaskCommand = mapper.Map<UpdateUserTaskCommand>(userTask);
				await _client.UserTasksPUTAsync(id.ToString(), updateUserTaskCommand);
				return new Response<Guid>()
				{
					Success = true
				};
			}
			catch (ApiException ex)
			{
				return convertApiExceptions<Guid>(ex);
			}
		}
	}
}
