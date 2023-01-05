using Backend.Core.Application.Features.CQRS.Commands.Categories;
using Backend.Core.Application.Interfaces;
using Backend.Core.Domain;
using MediatR;

namespace Backend.Core.Application.Features.CQRS.Handlers.Categories;
public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest>
{
    private readonly IRepository<Category> _repository;

    public DeleteCategoryCommandHandler(IRepository<Category> repository) => _repository = repository;
     
    public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var deleted = await _repository.GetByIdAsync(request.Id);
        if (deleted != null)
            await _repository.RemoveAsync(deleted);
        return Unit.Value;
    }
}
