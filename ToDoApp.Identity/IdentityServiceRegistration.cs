using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ToDoApp.Application.Contracts.Identity;
using ToDoApp.Application.Models.Identity;
using ToDoApp.Identity.DbContext;
using ToDoApp.Identity.Models;
using ToDoApp.Identity.Services;

namespace ToDoApp.Identity
{ 
	public static class IdentityServiceRegistration
	{
		public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
		{

			services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

			services.AddDbContext<ToDoIdentityDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("ToDoAppConnectionString"));
			});

			services.AddIdentity<ApplicationUser, IdentityRole>()
							.AddEntityFrameworkStores<ToDoIdentityDbContext>()
							.AddDefaultTokenProviders();

			services.AddTransient<IAuthService,AuthService>();

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero,
					ValidIssuer = configuration["JwtSettings:Issuer"],
					ValidAudience = configuration["JwtSettings:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
				};
			});

			return services;
		}
	}
}
