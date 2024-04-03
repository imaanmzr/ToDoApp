using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Identity.Models;

namespace ToDoApp.Identity.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			var hasher = new PasswordHasher<ApplicationUser>();
			builder.HasData(
				 new ApplicationUser
				 {
					 Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
					 Email = "admin@localhost.com",
					 NormalizedEmail = "ADMIN@LOCALHOST.COM",
					 FirstName = "System",
					 LastName = "Admin",
					 UserName = "admin@localhost.com",
					 NormalizedUserName = "ADMIN@LOCALHOST.COM",
					 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
					 EmailConfirmed = true
				 }
			);
		}
	}
}
