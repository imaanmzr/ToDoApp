using ToDoApp.Domain.Entities;

namespace ToDoApp.Domain.Contracts.Repositories
{
	public interface ICategoryRepository : IGenericRepository<Category>
	{
		Task<List<Category>> GetAllCategories();
		Task<Category> GetCategoryById(int id);
		Task<bool> IsCategoryNameExists(string name);


	}
}
