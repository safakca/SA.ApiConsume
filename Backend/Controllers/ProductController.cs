using Backend.Core.Application.Features.CQRS.Commands.Products;
using Backend.Core.Application.Features.CQRS.Queries.Products;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Get All Product
    /// </summary>
    /// <returns></returns> 
    [HttpGet("[action]")]
    public async Task<IActionResult> List() => Ok(await _mediator.Send(new GetProductsQueryRequest()));

    /// <summary>
    /// Delete Product
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> Delete(int id) => Ok(await _mediator.Send(new DeleteProductCommandRequest(id)));

    /// <summary>
    /// Create Product
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateProductCommandRequest request) => Created("", await _mediator.Send(request));

    /// <summary>
    /// Update Product
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateProductCommandRequest request) => Ok(await _mediator.Send(request));

    /// <summary>
    /// Get By Id Product
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("[action]/{id}")] //TODO: CREATE CUSTOM EXCEPTION CLASS AND DELETE TERNARY IN CONTROLLER
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetProductByIdQueryRequest(id));
        return result == null ? NotFound() : Ok(result);
    }
}
