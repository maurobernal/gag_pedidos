using WebAPI.Entities;
using WebAPI.Infrastructure;
using WebAPI.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace WebAPI.Services;

public class TipoDeProductoService : ITipoDeProductoService
{
    private readonly AppDBContext _conexion;
    private readonly IMapper _mapper;
    public TipoDeProductoService(IMapper mapper)
    {
        _conexion = new AppDBContext();
        _mapper = mapper;
    }
    public int AddTipoDeProducto(TipoDeProductoDTO tipoDeProducto)
    {
        var O = _mapper.Map<Producto>(tipoDeProducto);
        _conexion.Add(O);

        _conexion.SaveChanges();
        return tipoDeProducto.Id;
    }

    public bool UpdateTipoDeProducto(TipoDeProductoDTO tipoDeProducto)
    {

        var entidad = _conexion.TipoDeProductos.Where(o => o.Id == tipoDeProducto.Id).FirstOrDefault();
        if (entidad == null) return false;

        var O = _mapper.Map<Producto>(tipoDeProducto);
        _conexion.Add(O);

        _conexion.SaveChanges();
        return true;
    }

    public bool DeleteTipoDeProducto(int ID)
    {
        var entidad = _conexion.TipoDeProductos.Where(o => o.Id == ID).FirstOrDefault();
        if (entidad == null) return false;
        _conexion.Remove(entidad);

        _conexion.SaveChanges();
        return true;

    }

    public TipoDeProductoDTO SelectTipoDeProducto(int ID)
  => _conexion.TipoDeProductos.Where(o => o.Id == ID && o.Habilitado == true).ProjectTo<TipoDeProductoDTO>(_mapper.ConfigurationProvider).FirstOrDefault();


    public List<TipoDeProductoDTO> SelectListTipoDeProducto() 
    {
        var List_O = _conexion.Origenes.Where(o => o.Habilitado == true).ToList();

        return _mapper.Map<List<TipoDeProductoDTO>>(List_O);

    }
     



}

