using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using ToDoApp.BlazorUI.Contracts;
using ToDoApp.BlazorUI.Providers;
using ToDoApp.BlazorUI.Services.Base;

namespace ToDoApp.BlazorUI.Services
{
	public class AuthenticationService : BaseHttpService, IAuthenticationService
	{
		private readonly AuthenticationStateProvider _authenticationStateProvider;

		public AuthenticationService(IClient client,
									 ILocalStorageService localStorageService,
									 AuthenticationStateProvider authenticationStateProvider) : base(client, localStorageService)
		{
			_authenticationStateProvider = authenticationStateProvider;
		}

		public async Task<bool> AuthenticationAsync(string email, string password)
		{
			try
			{
				AuthRequest authenticationRequest = new AuthRequest
				{
					Email = email,
					Password = password
				};
				var authenticationResponse = await _client.LoginAsync(authenticationRequest);

				if (authenticationResponse.Token != string.Empty)
				{
					await _localStorageService.SetItemAsync("token", authenticationResponse.Token);

					// Set claims in Blazor and login state

					await((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();

					return true;
				}
				return false;
			}
			catch (Exception)
			{

				return false;
			}
		}

		public async Task Logout()
		{
			await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
		}

		public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
		{
			RegistrationRequest registrationRequest = new RegistrationRequest
			{
			FirstName = firstName,
			LastName = lastName,
			UserName = userName,
			Email = email,
			Password = password
			};
				
			var response = await _client.RegisterAsync(registrationRequest);

			if (!string.IsNullOrEmpty(response.UserId))
			{
				return true;
			}
			return false;
		}
	}
}
