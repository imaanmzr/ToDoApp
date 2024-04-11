﻿

namespace ToDoApp.Application.Features.BaseDtos
{
	public abstract class CategoryBaseDto
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }
	}
}
