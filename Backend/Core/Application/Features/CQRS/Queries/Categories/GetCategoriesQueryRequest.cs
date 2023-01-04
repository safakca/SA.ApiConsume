using Backend.Core.Application.Dtos;
using MediatR;

namespace Backend.Core.Application.Features.CQRS.Queries.Categories;
public class GetCategoriesQueryRequest : IRequest<List<CategoryDto>>
{
}
