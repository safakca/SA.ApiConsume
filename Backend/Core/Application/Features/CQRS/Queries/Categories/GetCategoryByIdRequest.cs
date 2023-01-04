using Backend.Core.Application.Dtos;
using MediatR;

namespace Backend.Core.Application.Features.CQRS.Queries.Categories;
public class GetCategoryByIdRequest : IRequest<CategoryDto?>
{
    public int Id { get; set; }
    public GetCategoryByIdRequest(int id)
    {
        Id = id;
    }
}
