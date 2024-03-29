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
	public class CategoryConfiguration: IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("T_Categories");

			builder.HasKey(p => p.Id);

			builder.Property(p => p.Id)
								.ValueGeneratedOnAdd();

			builder.Property(p => p.Name)
								.IsRequired()
								.HasMaxLength(100);

			builder.Property(p => p.Description)
								.HasMaxLength(500);

			builder.HasMany(c => c.UserTasks)
								.WithOne(ut => ut.Category)
								.HasForeignKey(ut => ut.CategoryId);
				

			builder.HasData(
							new Category
							{
								Id = 1,
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								Description = "Category",
								Name = "Sleep"
							}
							);
		}
	}
}
