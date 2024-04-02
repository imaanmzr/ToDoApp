using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Contracts.Identity;
using ToDoApp.Application.Exceptions;
using ToDoApp.Application.Models.Identity;
using ToDoApp.Identity.Models;

namespace ToDoApp.Identity.Services
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly JwtSettings jwtSettings;

		public AuthService(UserManager<ApplicationUser> userManager,
						   SignInManager<ApplicationUser> signInManager,
						   IOptions<JwtSettings> jwtSettings)

		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.jwtSettings = jwtSettings.Value;
		}
		public async Task<AuthResponse> Login(AuthRequest request)
		{
			var user = await userManager.FindByEmailAsync(request.Email);
			if (user == null)
			{
				throw new NotFoundException($"User with {request.Email} not found", request.Email);
			}
			var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);

			if (!result.Succeeded)
			{
				throw new BadRequestException($"The email or password you entered is incorrect");
			}

			JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

			var response = new AuthResponse
			{
				Id = user.Id,
				Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
				Email = user.Email,
				UserName = user.UserName
			};

			return response;
		}

	
		public async Task<RegistrationResponse> Register(RegistrationRequest request)
		{
			var user = new ApplicationUser
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				UserName = request.UserName,
				EmailConfirmed = true
			};

			var result = await userManager.CreateAsync(user, request.Password);

			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(user, "User");
				return new RegistrationResponse() { UserId = user.Id };
			}
			else
			{
				StringBuilder str = new StringBuilder();
				foreach (var error in result.Errors)
				{
					str.AppendFormat("•{0}\n", error.Description);
				}

				throw new BadRequestException($"{str}");
			}
		}


		private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
		{
			var userClaims = await userManager.GetClaimsAsync(user);
			var roles = await userManager.GetRolesAsync(user);

			var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim("uid", user.Id)
			}
			.Union(userClaims)
			.Union(roleClaims);

			var symmettricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));

			var signingCredentials = new SigningCredentials(symmettricSecurityKey, SecurityAlgorithms.HmacSha256);

			var jwtSecurityToken = new JwtSecurityToken(
				issuer: jwtSettings.Issuer,
				audience: jwtSettings.Audience,
				claims: claims,
				expires: DateTime.Now.AddMinutes(jwtSettings.DurationInMinutes),
				signingCredentials: signingCredentials
				);

			return jwtSecurityToken;
		}
	}
}
