using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;


namespace ToDoApp.Persistence.Configuations
{
	public class UserTaskConfiguration : IEntityTypeConfiguration<UserTask>
	{
		public void Configure(EntityTypeBuilder<UserTask> builder)
		{
			builder.ToTable("T_UserTasks");

			builder.HasKey(p => p.Id);

			builder.Property(p => p.Id)
								 .ValueGeneratedOnAdd();

			builder.Property(p => p.Title)
							  	 .IsRequired()
								 .HasMaxLength(100);

			builder.Property(p => p.Description)
								 .HasMaxLength(500);

			builder.HasOne(ut => ut.User)
								 .WithMany(u => u.UserTasks)
								 .HasForeignKey(ut => ut.UserId)
								 .OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(ut => ut.Category)
								 .WithMany(c => c.UserTasks)
								 .HasForeignKey(ut => ut.CategoryId);


			builder.HasData(
						   new UserTask
						   {
						   		Id = 1,
						   		Title = "Title",
						   		Description = "Description",
						   		DateModified = DateTime.UtcNow,
						   		DueDate = DateTime.UtcNow,
						   		CategoryId = 1,
						   		DateCreated = DateTime.UtcNow,
						   		IsCompleted = true,
						   		UserId = 1
						   }
						   );
		}
	}
}
