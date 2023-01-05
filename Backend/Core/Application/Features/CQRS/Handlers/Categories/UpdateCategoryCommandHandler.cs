using Backend.Core.Application.Features.CQRS.Commands.Categories;
using Backend.Core.Application.Interfaces;
using Backend.Core.Domain;
using MediatR;

namespace Backend.Core.Application.Features.CQRS.Handlers.Categories;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
{
    private readonly IRepository<Category> _repository;

    public UpdateCategoryCommandHandler(IRepository<Category> repository) => _repository = repository;
     
    public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var updated = await _repository.GetByIdAsync(request.Id);
        if (updated != null)
        {
            updated.Defination = request.Defination;
            await _repository.UpdateAsync(updated);
        }
        return Unit.Value;
    }
}
