using ToDoApp.Domain.Contracts.Repositories;
using ToDoApp.Domain.Entities;
using ToDoApp.Persistence.DatabaseContext;

namespace ToDoApp.Persistence.Repositories
{
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(ToDoDbContext db) : base(db)
		{

		}
	}
}
