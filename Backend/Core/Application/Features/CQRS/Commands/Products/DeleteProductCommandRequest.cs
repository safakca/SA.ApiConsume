using MediatR;

namespace Backend.Core.Application.Features.CQRS.Commands.Products;
public record DeleteProductCommandRequest(int Id) : IRequest { }
