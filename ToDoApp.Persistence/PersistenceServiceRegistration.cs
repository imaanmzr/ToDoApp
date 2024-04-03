using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Contracts.Repositories;
using ToDoApp.Persistence.DatabaseContext;
using ToDoApp.Persistence.Repositories;

namespace ToDoApp.Persistence
{
	public static class PersistenceServiceRegistration
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ToDoDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("ToDoAppConnectionString"));
			});
			//Registering repository services
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped(typeof(IUserTaskRepository), typeof(UserTaskRepository));
			services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));

			return services;
		}
	}
}
