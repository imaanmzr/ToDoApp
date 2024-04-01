using ToDoApp.BlazorUI.Contracts;
using ToDoApp.BlazorUI.Services.Base;

namespace ToDoApp.BlazorUI.Services
{
	public class CategoryService : BaseHttpService, ICategoryService
	{
		public CategoryService(IClient client) : base(client)
		{
		}
	}
}
