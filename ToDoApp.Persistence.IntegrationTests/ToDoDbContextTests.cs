using Microsoft.EntityFrameworkCore;
using Shouldly;
using ToDoApp.Domain.Entities;
using ToDoApp.Persistence.DatabaseContext;

namespace ToDoApp.Persistence.IntegrationTests
{
	public class ToDoDbContextTests
	{
		private ToDoDbContext toDoDbContext;

		public ToDoDbContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<ToDoDbContext>()
								.UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
			toDoDbContext = new ToDoDbContext(dbOptions);
        }

        [Fact]
		public async void Save_SetDateCreatedValue()
		{
			var userTask = new UserTask
			{
				Id = 1,
				Title = "Test Working",
				Description = "Test Working Description",
				CategoryId = 1,
				DueDate = DateTime.Now.AddDays(10),
				IsCompleted = false,
				UserId = 1
			};

			await toDoDbContext.UserTasks.AddAsync(userTask);
			await toDoDbContext.SaveChangesAsync();

			userTask.DateCreated.ShouldNotBeNull();
		}

		[Fact]
		public async void Save_SetDateModifiedValue()
		{
			var userTask = new UserTask
			{
				Id = 1,
				Title = "Test Working",
				Description = "Test Working Description",
				CategoryId = 1,
				DueDate = DateTime.Now.AddDays(10),
				IsCompleted = false,
				UserId = 1
			};

			await toDoDbContext.UserTasks.AddAsync(userTask);
			await toDoDbContext.SaveChangesAsync();

			userTask.DateModified.ShouldNotBeNull();

		}
	}
}