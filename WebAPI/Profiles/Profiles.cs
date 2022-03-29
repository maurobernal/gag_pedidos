using AutoMapper;
using WebAPI.DTOs;
using WebAPI.Entities;

namespace WebAPI.Profiles;

public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<OrigenDTO, Origen>().ReverseMap();
        //.ForMember(d => d.Descripcion, o=> o.MapFrom(p=> p.Canal + ":" + p.Nombre) )

        CreateMap<ProductoDTO, Producto>().ReverseMap();
        CreateMap<TipoDeProductoDTO, TipoDeProducto>().ReverseMap();
        

    }

}
