using Backend.Core.Application.Features.CQRS.Commands.Products;
using Backend.Core.Application.Features.CQRS.Queries.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var result = await _mediator.Send(new GetProductsQueryRequest());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetProductByIdQueryRequest(id));
        return result == null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteProductCommandRequest(id));
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommandRequest request)
    {
        await _mediator.Send(request);
        return Created("", request);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductCommandRequest request)
    {
        await _mediator.Send(request);
        return NoContent();
    }
}
