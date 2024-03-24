using ToDoApp.Domain.Contracts.Repositories;
using ToDoApp.Domain.Entities;
using ToDoApp.Persistence.DatabaseContext;

namespace ToDoApp.Persistence.Repositories
{
	public class UserTaskRepository : GenericRepository<UserTask>, IUserTaskRepository
	{
        public UserTaskRepository(ToDoDbContext db):base(db)
        {
            
        }

        public Task<bool> IsUserTaskUnique(string title)
		{
			throw new NotImplementedException();
		}
	}
}
