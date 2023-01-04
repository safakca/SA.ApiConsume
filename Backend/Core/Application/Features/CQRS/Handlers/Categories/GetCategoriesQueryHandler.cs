using Backend.Core.Application.Dtos;
using Backend.Core.Application.Features.CQRS.Queries.Categories;
using Backend.Core.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Backend.Core.Application.Features.CQRS.Handlers.Categories;
using Backend.Core.Domain;


public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, List<CategoryDto>>
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;

    public GetCategoriesQueryHandler(IRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<CategoryDto>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetAllAsync();
        return _mapper.Map<List<CategoryDto>>(data);
    }
}
