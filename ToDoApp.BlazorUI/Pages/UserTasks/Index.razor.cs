using Microsoft.AspNetCore.Components;
using ToDoApp.BlazorUI.Contracts;
using ToDoApp.BlazorUI.Models.UserTasks;

namespace ToDoApp.BlazorUI.Pages.UserTasks
{
	public partial class Index
	{
		[Inject]
		public NavigationManager NavigationManager { get; set; }

		[Inject]
		public IUserTaskService UserTaskService { get; set; }

		public List<UserTaskViewModel> UserTasks { get; set; }
		public string Message { get; set; } = string.Empty;

		protected void CreateUserTask()
		{
			NavigationManager.NavigateTo("/tasks/create");
		}

		protected void ChooseCategory(int id)
		{
			//use category service
		}

		protected void EditUserTask(int id)
		{
			NavigationManager.NavigateTo($"/tasks/edit/{id}");
		}
		protected void DetailsUserTask(int id)
		{
			NavigationManager.NavigateTo($"/tasks/details/{id}");
		}

		protected async Task DeleteUserTask(int id)
		{
			var response = await UserTaskService.DeleteUserTask(id);
            if (response.Success)
            {
				StateHasChanged();
            }
			else
			{
				Message = response.Message;
			}
        }

		protected override async Task OnInitializedAsync()
		{
			UserTasks = await UserTaskService.GetAllUserTasks();
		}
	}
}