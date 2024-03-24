using ToDoApp.Domain.Contracts.Repositories;
using ToDoApp.Domain.Entities;
using ToDoApp.Persistence.DatabaseContext;

namespace ToDoApp.Persistence.Repositories
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{
		public UserRepository(ToDoDbContext db) : base(db)
		{

		}
	}
}
