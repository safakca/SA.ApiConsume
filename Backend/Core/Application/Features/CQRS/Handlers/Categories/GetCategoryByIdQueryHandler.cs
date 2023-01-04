using Backend.Core.Application.Dtos;
using Backend.Core.Application.Interfaces;
using MediatR;

namespace Backend.Core.Application.Features.CQRS.Handlers.Categories;

using AutoMapper;
using Backend.Core.Application.Features.CQRS.Queries.Categories;
using Backend.Core.Domain;
public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdRequest, CategoryDto?>
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;

    public GetCategoryByIdQueryHandler(IRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CategoryDto?> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByFilter(x => x.Id == request.Id);
        return _mapper.Map<CategoryDto>(result);
    }
}
