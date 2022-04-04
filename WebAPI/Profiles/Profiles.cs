using AutoMapper;
using WebAPI.DTOs;
using WebAPI.Entities;
namespace WebAPI.Profiles;
    public class Profiles: Profile
    {
    public Profiles()
    {
        CreateMap<OrigenDTO, Origen>()
            .ForMember(d => d.Descripcion, o => o.MapFrom(p => p.Canal + ":" + p.Tipo))
            .ForMember(d => d.Descripcion, o => o.MapFrom(p => p.Canal + ":" + p.Tipo))
            .ForMember(d => d.Descripcion, o => o.MapFrom(p => p.Canal + ":" + p.Tipo))
            .ForMember(d => d.Descripcion, o => o.MapFrom(p => p.Canal + ":" + p.Tipo))
            .ForMember(d => d.Descripcion, o => o.MapFrom(p => p.Canal + ":" + p.Tipo))
            .ReverseMap()
            .ForMember(d => d.Canal, o => o.MapFrom(p => p.Descripcion));
            ;
    }
    }

