using ToDoApp.BlazorUI.Models.UserTasks;
using ToDoApp.BlazorUI.Services.Base;

namespace ToDoApp.BlazorUI.Contracts
{
	public interface IUserTaskService
	{
		Task<List<UserTaskViewModel>> GetAllUserTasks();
		Task<UserTaskViewModel> GetUserTaskById(int id);
		Task<Response<Guid>> CreateUserTask(UserTaskViewModel userTask);
		Task<Response<Guid>> UpdateUserTask(int id, UserTaskViewModel userTask);
		Task<Response<Guid>> DeleteUserTask(int id);
	}
}
