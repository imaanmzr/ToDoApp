using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Common;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Persistence.DatabaseContext
{
	public class ToDoDbContext : DbContext
	{
		public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
		{

		}

		public DbSet<UserTask> UserTasks { get; set; }
		public DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToDoDbContext).Assembly);

			base.OnModelCreating(modelBuilder);
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			foreach (var entry in ChangeTracker.Entries<BaseEntity>()
		            .Where(q=>q.State == EntityState.Added || q.State == EntityState.Modified))
			{
			entry.Entity.DateModified = DateTime.Now;
				if (entry.State == EntityState.Added)
				{
					entry.Entity.DateCreated = DateTime.Now;
				}
			}

			return base.SaveChangesAsync(cancellationToken);
		}
	}
}
