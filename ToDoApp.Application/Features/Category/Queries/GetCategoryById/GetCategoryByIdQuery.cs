using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Features.Category.Queries.GetCategoryById
{
	public record GetCategoryByIdQuery : IRequest<GetCategoryByIdDto>
	{
		public int Id { get; set; }
	}
}
