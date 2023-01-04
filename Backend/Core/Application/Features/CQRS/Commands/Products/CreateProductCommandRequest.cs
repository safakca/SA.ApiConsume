using MediatR;

namespace Backend.Core.Application.Features.CQRS.Commands.Products;
public class CreateProductCommandRequest : IRequest
{
    public string? Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}
