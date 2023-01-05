using MediatR;

namespace Backend.Core.Application.Features.CQRS.Commands.Categories;
public class UpdateCategoryCommandRequest : IRequest
{
    public int Id { get; set; }
    public string? Defination { get; set; }
}
