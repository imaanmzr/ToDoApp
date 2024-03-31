using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToDoApp.Application.Exceptions;
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

		public async Task<List<Category>> GetAllCategories()
		{
			var categories = await db.Categories
									 .Include(c => c.UserTasks)
									 .ToListAsync();
			if (categories != null && categories.Count > 0)
				return categories;

			throw new Exception("There is no category added");
		}

		public async Task<Category> GetCategoryById(int id)
		{
			var category = await db.Categories
									.AsNoTracking()
									.Include(c => c.UserTasks)
									.FirstOrDefaultAsync(c => c.Id == id);
			if (category != null)
				return category;

			throw new Exception("Category not found");
		}

		public async Task<bool> IsCategoryNameExists(string name)
		{
			return await db.Categories.AnyAsync(c => c.Name == name) == false;
		}
	}
}
