using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Features.Category.Commands.UpdateCategory
{
	public class UpdateCategoryCommand : IRequest<Unit>
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
	}
}
