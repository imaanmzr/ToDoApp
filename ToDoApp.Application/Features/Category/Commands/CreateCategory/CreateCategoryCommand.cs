using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Features.Category.Commands.CreateCategory
{
	public class CreateCategoryCommand : IRequest<int>
	{
		public string? Name { get; set; }
		public string? Description { get; set; }
	}
}
