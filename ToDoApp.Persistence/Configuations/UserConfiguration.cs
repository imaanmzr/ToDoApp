using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Persistence.Configuations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("T_Users");

			builder.HasKey(p => p.Id);

			builder.Property(p => p.Id)
								 .ValueGeneratedOnAdd();

			builder.Property(p => p.FirstName)
								.IsRequired()
								.HasMaxLength(50);

			builder.Property(p => p.LastName)
								.IsRequired()
								.HasMaxLength(50);

			builder.Property(p => p.Email)
								.IsRequired()
								.HasMaxLength(100);

			builder.Property(p => p.PasswordHash)
								.IsRequired();

			builder.HasMany(u => u.UserTasks)
								.WithOne(ut => ut.User)
								.HasForeignKey(ut => ut.UserId);
								

			builder.HasData(
							new User
							{
								Id = 1,
								FirstName ="John",
								LastName = "Doe",
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								Email = "user@user.com",
								PasswordHash = "112233"
							}
							);
		}
	}
}
