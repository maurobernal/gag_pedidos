using WebAPI.Entities;
using WebAPI.Infrastructure;
using WebAPI.DTOs;
using WebAPI.Interfaces;
using AutoMapper;

using AutoMapper.QueryableExtensions;

namespace WebAPI.Services;

public class OrigenService : IOrigenService
{
    private readonly AppDBContext _conexion;
    private readonly IMapper _mapper;
    public OrigenService(IMapper mapper)
    {
        _conexion = new AppDBContext();
        _mapper = mapper;   
    }
    public int AddOrigen(OrigenDTO origen)
    {
        //OrigenDTO => Origen
        //Origen O = new Origen();
        //O.Descripcion = origen.Descripcion;
        var O=_mapper.Map<Origen>(origen);
        
        O.Habilitado = true;
        

        _conexion.Origenes.Add(O);
        _conexion.SaveChanges();
        return origen.Id;
    }

    public bool UpdateOrigen(OrigenDTO origen)
    {

        Origen entidad = _conexion.Origenes.Where(o => o.Id == origen.Id).FirstOrDefault();
        if (entidad == null) return false;


        entidad.Descripcion = origen.Canal;
        _conexion.SaveChanges();
        return true;
    }

    public bool DeleteOrigen(int ID)
    {
        var entidad = _conexion.Origenes.Where(o => o.Id == ID).FirstOrDefault();
        if (entidad == null) return false;
        _conexion.Remove(entidad);
        _conexion.SaveChanges();
        return true;

    }

    public OrigenDTO SelectOrigen(int ID)
    {
        var O=  _conexion.Origenes
            .Where(o => o.Id == ID && o.Habilitado == true).FirstOrDefault();

        return _mapper.Map<OrigenDTO>(O);
    }


    public List<OrigenDTO> SelectListOrigen() 
     
       =>
            _conexion.Origenes.Where(o => o.Habilitado == true)
            .ProjectTo<OrigenDTO>(_mapper.ConfigurationProvider)
            .ToList();
        

   



}
