using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Features.BaseDtos
{
	public class CategoryBaseDto
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }
	}
}
