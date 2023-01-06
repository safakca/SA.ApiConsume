using Backend.Core.Application.Features.CQRS.Commands.Categories;
using Backend.Core.Application.Features.CQRS.Queries.Categories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin,Member")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    public CategoryController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Get All Category
    /// </summary>
    /// <returns></returns>
    [HttpGet("[action]")]
    public async Task<IActionResult> List() => Ok(await _mediator.Send(new GetCategoriesQueryRequest()));

    /// <summary>
    /// Create Category
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateCategoryCommandRequest request) => Created("", await _mediator.Send(request));

    /// <summary>
    /// Update Category
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateCategoryCommandRequest request) => Ok(await _mediator.Send(request));

    /// <summary>
    /// Delete Category
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> Delete(int id) => Ok(await _mediator.Send(new DeleteCategoryCommandRequest(id)));

    /// <summary>
    /// Get By Id Category
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("[action]/{id}")]  //TODO: CREATE CUSTOM EXCEPTION CLASS AND DELETE TERNARY IN CONTROLLER
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetCategoryByIdRequest(id));
        return result == null ? NotFound() : Ok(result);
    }
}
