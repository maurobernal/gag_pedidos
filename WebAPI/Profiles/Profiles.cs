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
        CreateMap<OrderDTO, Order>().ReverseMap();
        CreateMap<OrderDetailDTO, OrderDetail>()
            .ForMember(d=>d.Product,o=>o.MapFrom(m=>m.ProductItem))
            .ReverseMap()
            .ForMember(d=>d.ProductItem, o=>o.MapFrom(d=>d.Product));
            
    }
}

