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
		private readonly ToDoDbContext db;

		public GenericRepository(ToDoDbContext db)
        {
			this.db = db;
		}

        public Task CreateAsync(T entity)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(T entity)
		{
			throw new NotImplementedException();
		}

		public Task<IReadOnlyList<T>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<T> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(T entity)
		{
			throw new NotImplementedException();
		}
	}
}
