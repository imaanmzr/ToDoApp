using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Persistence.Configuations
{
	public class CategoryConfiguration
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasData(

				new Category
				{
					

				}
				) ;
			builder.Property(p=>p.Name).IsRequired().HasMaxLength(100);
			builder.Property(p=>p.Description).HasMaxLength(500);
		
		}
	}
}
