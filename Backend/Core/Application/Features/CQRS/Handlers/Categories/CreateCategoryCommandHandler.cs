
using Backend.Core.Application.Features.CQRS.Commands.Categories;
using MediatR;

namespace Backend.Core.Application.Features.CQRS.Handlers.Categories;

using Backend.Core.Application.Interfaces;
using Backend.Core.Domain;
public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest>
{
    private readonly IRepository<Category> _repository;
    public CreateCategoryCommandHandler(IRepository<Category> repository)
    {
        _repository=repository;
    }
    public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Category{
            Defination=request.Defination,
        });
        return Unit.Value;
    }
}