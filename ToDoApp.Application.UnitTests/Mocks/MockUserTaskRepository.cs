using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Contracts.Repositories;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.UnitTests.Mocks
{
	public class MockUserTaskRepository
	{
		public static Mock<IUserTaskRepository> GetMockUserTaskRepository()
		{
			var userTasks = new List<UserTask>
			{
				new UserTask
				{
					Id = 1,
					Title = "Test Working",
					Description = "Test Working Description",
					CategoryId = 1,
					DateCreated = DateTime.Now,
					DateModified = DateTime.Now,
					DueDate = DateTime.Now.AddDays(10),
					IsCompleted = false,
				},
				new UserTask
				{
					Id = 2,
					Title = "Test Playing",
					Description = "Test Playing Description",
					CategoryId = 2,
					DateCreated = DateTime.Now,
					DateModified = DateTime.Now,
					DueDate = DateTime.Now.AddDays(5),
					IsCompleted = false,
				},
					new UserTask
				{
					Id = 3,
					Title = "Test Reading Book",
					Description = "Test Reading Book Description",
					CategoryId = 3,
					DateCreated = DateTime.Now,
					DateModified = DateTime.Now,
					DueDate = DateTime.Now.AddDays(2),
					IsCompleted = false,
				}
			};

			var mockRepo = new Mock<IUserTaskRepository>();
			mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(userTasks);
			
			mockRepo.Setup(r => r.CreateAsync(It.IsAny<UserTask>())).Returns((UserTask userTask) =>
			{
				userTasks.Add(userTask);
				return Task.CompletedTask;
			});

			return mockRepo;
		}
	}
}
