using AutoMapper;
using Backend.Core.Application.Dtos;
using Backend.Core.Domain;

namespace Backend.Core.Application.Mappings;
public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
