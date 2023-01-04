using Backend.Core.Application.Dtos;
using MediatR;

namespace Backend.Core.Application.Features.CQRS.Queries.Products;
public class GetProductsQueryRequest : IRequest<List<ProductDto>>
{
}
