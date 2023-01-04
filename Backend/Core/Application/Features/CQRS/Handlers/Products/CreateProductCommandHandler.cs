using Backend.Core.Application.Features.CQRS.Commands.Products;
using Backend.Core.Application.Interfaces;
using MediatR;

namespace Backend.Core.Application.Features.CQRS.Handlers.Products;
using Backend.Core.Domain;
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
{
    private readonly IRepository<Product> _repository;

    public CreateProductCommandHandler(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Product
        {
            CategoryId = request.CategoryId,
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock,
        });
        return Unit.Value;
    }
}
