using System.ComponentModel.DataAnnotations;

namespace ToDoApp.BlazorUI.Models.UserTasks
{
	public class UserTaskViewModel
	{
		public int Id { get; set; }
		[Required]
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;

		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }

		[Required]
		public DateTime DueDate { get; set; }
		[Required]
		public bool IsCompleted { get; set; }
		public int CategoryId { get; set; }
	}
}
