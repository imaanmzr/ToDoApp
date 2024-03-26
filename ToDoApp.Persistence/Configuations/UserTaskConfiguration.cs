using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Factories;
using ToDoApp.Domain.Entities;


namespace ToDoApp.Persistence.Configuations
{
	public class UserTaskConfiguration
	{
		private readonly IGenericFactory<UserTask> genericFactory;

		public UserTaskConfiguration(IGenericFactory<UserTask> genericFactory)
        {
			this.genericFactory = genericFactory;
		}
        public void Configure(EntityTypeBuilder<UserTask> builder)
		{
			builder.HasData(
				genericFactory.CreateNewUserTask(
												id:1,
												title:"test",
												description:"this is a test task",
												dueDate:DateTime.Now.AddDays(10),
												dateModified:DateTime.Now,
												isCompleted:false
												)
						   );

			builder.Property(p=>p.Title).IsRequired().HasMaxLength(100);
			builder.Property(p => p.Description).HasMaxLength(500);


		}
	}
}
