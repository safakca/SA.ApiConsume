using MediatR;

namespace Backend.Core.Application.Features.CQRS.Commands.Categories;
public record DeleteCategoryCommandRequest(int Id) : IRequest { }
