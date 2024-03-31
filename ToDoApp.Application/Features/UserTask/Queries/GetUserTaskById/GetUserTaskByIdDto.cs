using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Features.BaseDtos;

namespace ToDoApp.Application.Features.UserTask.Queries.GetUserTaskById
{
    public class GetUserTaskByIdDto : UserTaskBaseDto
	{
		public int CategoryId { get; set; }
	}
}
