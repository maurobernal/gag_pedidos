
using WebAPI.Infrastructure;
using WebAPI.Entities;
namespace WebAPI.Services;

public class TipoDeProductoService
{
    private readonly AppDBContext _conexion;
    public TipoDeProductoService()
    {
        _conexion = new AppDBContext();
    }
    public int AddTipoDeProducto(TipoDeProducto tipoDeProducto)
    {

        _conexion.Add(tipoDeProducto);
        _conexion.SaveChanges();
        return tipoDeProducto.Id;
    }

    public bool UpdateTipoDeProducto(TipoDeProducto tipoDeProducto)
    {

        var entidad = _conexion.TipoDeProductos.Where(o => o.Id == tipoDeProducto.Id).FirstOrDefault();
        if (entidad == null) return false;

        entidad.Descripcion = tipoDeProducto.Descripcion;
        entidad.Habilitado = tipoDeProducto.Habilitado;

        _conexion.Add(tipoDeProducto);

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

    public TipoDeProducto SelectTipoDeProducto(int ID)
  => _conexion.TipoDeProductos.Where(o => o.Id == ID && o.Habilitado == true).FirstOrDefault();


    public List<TipoDeProducto> SelectListTipoDeProducto() =>
        _conexion.TipoDeProductos.Where(o => o.Habilitado == true).ToList();



}

