﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Features.UserTask.Commands.CreateTask
{
	public class CreateUserTaskCommand : IRequest<int>
	{
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public DateTime DueDate { get; set; }
		public bool IsCompleted { get; set; } = false;
		public int CategoryId { get; set; }
		public int UserId { get; set; }
	}
}


