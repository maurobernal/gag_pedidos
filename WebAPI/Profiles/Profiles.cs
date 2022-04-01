using AutoMapper;
using WebAPI.DTOs;
using WebAPI.Entities;

namespace WebAPI.Profiles;
public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<OriginDTO, Origin>().ReverseMap();
        CreateMap<ProductDTO, Product>().ReverseMap();
        CreateMap<ProductTypeDTO, ProductType>().ReverseMap();
    }
}

