using ToDoApp.Domain.Entities;
using UserTask = ToDoApp.Domain.Entities.UserTask;

namespace ToDoApp.Domain.Contracts.Repositories
{
	public interface IUserTaskRepository : IGenericRepository<UserTask>
	{
		Task<bool> IsUserTaskExists(string title);
	}
}
