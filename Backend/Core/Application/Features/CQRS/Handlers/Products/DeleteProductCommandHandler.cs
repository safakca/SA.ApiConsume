using Backend.Core.Application.Features.CQRS.Commands.Products;
using Backend.Core.Application.Interfaces;
using MediatR;

namespace Backend.Core.Application.Features.CQRS.Handlers.Products;
using Backend.Core.Domain;
public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
{
    private readonly IRepository<Product> _repository;

    public DeleteProductCommandHandler(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        var deleted = await _repository.GetByIdAsync(request.Id);
        if (deleted != null)
            await _repository.RemoveAsync(deleted);
        return Unit.Value;
    }
}
