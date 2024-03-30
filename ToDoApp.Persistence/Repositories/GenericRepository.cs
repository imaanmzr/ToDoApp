using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Common;
using ToDoApp.Domain.Contracts.Repositories;
using ToDoApp.Persistence.DatabaseContext;

namespace ToDoApp.Persistence.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		protected readonly ToDoDbContext db;

		public GenericRepository(ToDoDbContext db)
        {
			this.db = db;
		}
		public async Task<IReadOnlyList<T>> GetAllAsync()
		{
			return await db.Set<T>().AsNoTracking().ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await db.Set<T>().AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);
		}
		public async Task CreateAsync(T entity)
		{
			await db.AddAsync(entity);
			await db.SaveChangesAsync();
		}
		public async Task UpdateAsync(T entity)
		{
			db.Entry(entity).State = EntityState.Modified;
			await db.SaveChangesAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			db.Remove(entity);
			await db.SaveChangesAsync();
		}
	}
}
