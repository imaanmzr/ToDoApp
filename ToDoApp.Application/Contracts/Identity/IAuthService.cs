using ToDoApp.Application.Models.Identity;

namespace ToDoApp.Application.Contracts.Identity
{
	public interface IAuthService
	{
		Task<AuthResponse> Login(AuthRequest request);
		Task<RegistrationResponse> Register(RegistrationRequest request);

	}
}
