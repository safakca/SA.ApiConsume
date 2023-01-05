using Backend.Core.Application.Features.CQRS.Commands.Products;
using Backend.Core.Application.Interfaces;
using MediatR;

namespace Backend.Core.Application.Features.CQRS.Handlers.Product;
using Backend.Core.Domain;
public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
{
    private readonly IRepository<Product> _repository;

    public UpdateProductCommandHandler(IRepository<Product> repository) => _repository = repository;
     
    public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var updated = await _repository.GetByIdAsync(request.Id);
        if (updated != null)
        {
            updated.CategoryId = request.CategoryId;
            updated.Stock = request.Stock;
            updated.Price = request.Price;
            updated.Name = request.Name;
            await _repository.UpdateAsync(updated);
        }
        return Unit.Value;
    }
}
