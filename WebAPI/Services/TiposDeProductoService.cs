using WebAPI.Entities;
namespace WebAPI.Services;

public class TiposDeProductoService
{
    public TiposDeProductoService()
    {
        entidades = new();
    }
    public List<TiposDeProducto> entidades { get; set; }
    public int AddTiposDeProducto(TiposDeProducto TiposDeProducto)
    {
        TiposDeProducto.Id = new Random().Next(100000);
        entidades.Add(TiposDeProducto);
        return TiposDeProducto.Id;
    }

    public bool UpdateTiposDeProducto(TiposDeProducto TiposDeProducto) {

        var entidad = entidades.Where(o => o.Id == TiposDeProducto.Id ).FirstOrDefault();
        if (entidad == null) return false;

        entidad.Descripcion = TiposDeProducto.Descripcion;
        entidad.Habilitado = TiposDeProducto.Habilitado;

        entidades.Add(TiposDeProducto);
        return true;
    }

    public bool DeleteTiposDeProducto(int ID)
    {
        var entidad = entidades.Where(o => o.Id == ID).FirstOrDefault();
        if (entidad == null) return false;
        entidades.Remove(entidad);
        return true;

    }

    public TiposDeProducto SelectTiposDeProducto(int ID) 
  => entidades.Where(o => o.Id == ID && o.Habilitado == true).FirstOrDefault();


    public List<TiposDeProducto> SelectListTiposDeProducto() =>
        entidades.Where(o => o.Habilitado == true).ToList();



}
