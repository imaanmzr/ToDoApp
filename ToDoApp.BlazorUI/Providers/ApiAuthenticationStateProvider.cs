using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ToDoApp.BlazorUI.Providers
{
	public class ApiAuthenticationStateProvider : AuthenticationStateProvider
	{
		private readonly ILocalStorageService localStorageService;
		private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler;

		public ApiAuthenticationStateProvider(ILocalStorageService localStorageService,
											  JwtSecurityTokenHandler jwtSecurityTokenHandler)
        {
			this.localStorageService = localStorageService;
			this.jwtSecurityTokenHandler = jwtSecurityTokenHandler;
		}
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			var user = new ClaimsPrincipal(new ClaimsIdentity());
			var isTokenPresent = await localStorageService.ContainKeyAsync("token");
			if (!isTokenPresent)
			{
				return new AuthenticationState(user);
			}

			var savedToken = await localStorageService.GetItemAsync<string>("token");
			var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken);

			if (tokenContent.ValidTo < DateTime.Now)
			{
			await localStorageService.RemoveItemAsync("token");
				return new AuthenticationState(user);
			}

			var claims = await GetClaimsAsync();
			user = new ClaimsPrincipal(new ClaimsIdentity(claims,"jwt"));

			return new AuthenticationState(user);
		}


		public async Task LoggedIn()
		{
			var claims = await GetClaimsAsync();
			var user = new ClaimsPrincipal(new ClaimsIdentity(claims,"jwt"));
			var authState = Task.FromResult(new AuthenticationState(user));
			NotifyAuthenticationStateChanged(authState);
		}

		public async Task LoggedOut()
		{
			await localStorageService.RemoveItemAsync("token");
			var nobody = new ClaimsPrincipal(new ClaimsIdentity());
			var authState = Task.FromResult(new AuthenticationState(nobody));
			NotifyAuthenticationStateChanged(authState);
		}

		private async Task<List<Claim>> GetClaimsAsync()
		{
			var savedToken = await localStorageService.GetItemAsync<string>("token");
			var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken);
			var claims = tokenContent.Claims.ToList();
			claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
			return claims;
		}
	}
}
