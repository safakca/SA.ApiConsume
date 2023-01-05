using Backend.Core.Application.Features.CQRS.Commands.Categories;
using Backend.Core.Application.Features.CQRS.Queries.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var result = await _mediator.Send(new GetCategoriesQueryRequest());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetCategoryByIdRequest(id));
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryCommandRequest request)
    {
        await _mediator.Send(request);
        return Created("", request);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCategoryCommandRequest request)
    {
        await _mediator.Send(request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteCategoryCommandRequest(id));
        return NoContent();
    }
}
