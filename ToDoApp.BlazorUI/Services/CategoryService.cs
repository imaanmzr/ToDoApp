using Blazored.LocalStorage;
using ToDoApp.BlazorUI.Contracts;
using ToDoApp.BlazorUI.Services.Base;

namespace ToDoApp.BlazorUI.Services
{
	public class CategoryService : BaseHttpService, ICategoryService
	{
		public CategoryService(IClient client,
							   ILocalStorageService localStorageService) : base(client, localStorageService)
		{
		}
	}
}
