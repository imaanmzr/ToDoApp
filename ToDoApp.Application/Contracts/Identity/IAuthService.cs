using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Models.Identity;

namespace ToDoApp.Application.Contracts.Identity
{
	public interface IAuthService
	{
		Task<AuthResponse> Login(AuthRequest request);
		Task<RegistrationResponse> Register(RegistrationRequest request);

	}
}
