using MediatR;

namespace Backend.Core.Application.Features.CQRS.Commands.Categories;
public class CreateCategoryCommandRequest : IRequest
{
    public string? Defination { get; set; } 
}
