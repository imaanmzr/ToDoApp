using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Features.Category.Commands.CreateCategory;
using ToDoApp.Application.Features.Category.Commands.DeleteCategory;
using ToDoApp.Application.Features.Category.Commands.UpdateCategory;
using ToDoApp.Application.Features.Category.Queries.GetAllCategories;
using ToDoApp.Application.Features.Category.Queries.GetCategoryById;
using ToDoApp.Application.Features.UserTask.Commands.DeleteUserTask;
using ToDoApp.Application.Features.UserTask.Commands.UpdateUserTask;

namespace ToDoApp.Api.Controllers.V1
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly IMediator mediator;

		public CategoriesController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetAllCategoriesDto>>> Get()
		{
			var categories = await mediator.Send(new GetAllCategoriesQuery());
			return Ok(categories);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetAllCategoriesDto>> Get(int id)
		{
			var categories = await mediator.Send(new GetCategoryByIdQuery { Id = id });
			return Ok(categories);
		}

		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Post(CreateCategoryCommand createCategory)
		{
			var response = await mediator.Send(createCategory);
			return CreatedAtAction(nameof(Get), new { id = response });
		}

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(400)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> Put(UpdateCategoryCommand updateCategory)
		{
			await mediator.Send(updateCategory);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var command = new DeleteCategoryCommand { Id = id };
			await mediator.Send(command);
			return NoContent();
		}
	}
}
