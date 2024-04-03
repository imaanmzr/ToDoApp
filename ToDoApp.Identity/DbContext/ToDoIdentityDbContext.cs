using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Identity.Models;

namespace ToDoApp.Identity.DbContext
{
	public class ToDoIdentityDbContext : IdentityDbContext<ApplicationUser>
	{
		public ToDoIdentityDbContext(DbContextOptions<ToDoIdentityDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.ApplyConfigurationsFromAssembly(typeof(ToDoIdentityDbContext).Assembly);
		}
	}
}
