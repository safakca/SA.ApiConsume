using Backend.Core.Application.Dtos;
using MediatR;

namespace Backend.Core.Application.Features.CQRS.Queries.Products;
public class GetProductByIdQueryRequest : IRequest<ProductDto>
{
    public int Id { get; set; }
    public GetProductByIdQueryRequest(int id)
    {
        Id = id;
    }
}
