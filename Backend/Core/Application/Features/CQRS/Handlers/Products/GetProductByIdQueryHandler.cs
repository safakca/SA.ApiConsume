using AutoMapper;
using Backend.Core.Application.Dtos;
using Backend.Core.Application.Features.CQRS.Queries.Products;
using Backend.Core.Application.Interfaces;
using MediatR;

namespace Backend.Core.Application.Features.CQRS.Handlers.Products;
using Backend.Core.Domain;
using Microsoft.AspNetCore.Mvc;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, ProductDto>
{
    private readonly IRepository<Product> _repository;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetByFilterAsync(x => x.Id == request.Id); 
        return _mapper.Map<ProductDto>(data);
    }
}
