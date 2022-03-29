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
        //Origen O = new Origen();
        //O.Descripcion = origen.Descripcion;

        var O = _mapper.Map<Origen>(origen);    

        _conexion.Add(O);
        _conexion.SaveChanges();
        return O.Id;
    }

    public bool UpdateOrigen(OrigenDTO origen)
    {

        var entidad = _conexion.Origenes.Where(o => o.Id == origen.Id).FirstOrDefault();
        if (entidad == null) return false;

        entidad.Descripcion = origen.Descripcion;

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
  => _conexion.Origenes.Where(o => o.Id == ID && o.Habilitado == true).ProjectTo<OrigenDTO>(_mapper.ConfigurationProvider).FirstOrDefault();


    public List<OrigenDTO> SelectListOrigen()
    {
        var List_O = _conexion.Origenes.Where(o => o.Habilitado == true).ToList();
        
        return _mapper.Map<List<OrigenDTO>>(List_O);
    }

       



}
