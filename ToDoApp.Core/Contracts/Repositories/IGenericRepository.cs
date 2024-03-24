using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Common;

namespace ToDoApp.Domain.Contracts.Repositories
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		Task<IReadOnlyList<T>> GetAllAsync();
		Task<T> GetByIdAsync(int id);
		Task CreateAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
	}
}
