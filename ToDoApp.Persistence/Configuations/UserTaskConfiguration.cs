using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;


namespace ToDoApp.Persistence.Configuations
{
	public class UserTaskConfiguration
	{
		public void Configure(EntityTypeBuilder<UserTask> builder)
		{
			builder.HasData(
				new UserTask
				{
					
				}
				);
			builder.Property(p=>p.Title).IsRequired().HasMaxLength(100);
			builder.Property(p => p.Description).HasMaxLength(500);

		}
	}
}
