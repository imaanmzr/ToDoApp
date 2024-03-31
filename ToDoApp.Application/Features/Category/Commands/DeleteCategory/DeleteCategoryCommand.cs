using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Features.Category.Commands.DeleteCategory
{
	public class DeleteCategoryCommand : IRequest<Unit>
	{
		public int Id { get; set; }
	}
}
