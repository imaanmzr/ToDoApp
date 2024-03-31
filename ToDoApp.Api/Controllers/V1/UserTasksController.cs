using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Features.UserTask.Commands.CreateTask;
using ToDoApp.Application.Features.UserTask.Commands.DeleteUserTask;
using ToDoApp.Application.Features.UserTask.Commands.UpdateUserTask;
using ToDoApp.Application.Features.UserTask.Queries.GetAllUserTasks;
using ToDoApp.Application.Features.UserTask.Queries.GetUserTaskById;


namespace ToDoApp.Api.Controllers.V1
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserTasksController : ControllerBase
	{
		private readonly IMediator mediator;

		public UserTasksController(IMediator mediator)
		{
			this.mediator = mediator;
		}


		[HttpGet]
		public async Task<ActionResult<List<GetAllUserTasksDto>>> Get()
		{
			var userTasks = await mediator.Send(new GetAllUserTasksQuery());
			return Ok(userTasks);
		}

		[HttpGet("{id}")]
		public async Task<GetUserTaskByIdDto> Get(int id)
		{
			var userTask = await mediator.Send(new GetUserTaskByIdQuery { Id = id });
			return userTask;
		}

		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Post(CreateUserTaskCommand createUserTask)
		{
			var response = await mediator.Send(createUserTask);
			return CreatedAtAction(nameof(Get), new { id = response });
		}

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(400)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> Put(UpdateUserTaskCommand updateUserTask)
		{
			await mediator.Send(updateUserTask);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var command = new DeleteUserTaskCommand { Id = id };
			await mediator.Send(command);
			return NoContent();
		}

	}
}
