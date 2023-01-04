using AutoMapper;
using Backend.Core.Application.Dtos;
using Backend.Core.Application.Features.CQRS.Queries.Products;
using Backend.Core.Application.Interfaces;
using MediatR;

namespace Backend.Core.Application.Features.CQRS.Handlers.Products;
using Backend.Core.Domain;
public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, List<ProductDto>>
{
    private readonly IRepository<Product> _repository;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetAllAsync();
        return _mapper.Map<List<ProductDto>>(data);
    }
}
