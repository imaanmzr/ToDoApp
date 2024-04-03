namespace ToDoApp.BlazorUI.Contracts
{
	public interface IAuthenticationService
	{
		Task<bool> AuthenticationAsync(string email, string password);
		Task<bool> RegisterAsync(string firstName,string lastName,string userName,string email,string password);
		Task Logout();
	}
}
