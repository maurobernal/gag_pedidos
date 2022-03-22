using WebAPI.Entities;
namespace WebAPI.Services;

public class TipoDeProductoService
{
    public TipoDeProductoService()
    {
        entidades = new();
    }
    public List<TipoDeProducto> entidades { get; set; }
    public int AddTipoDeProducto(TipoDeProducto tipoDeProducto)
    {
        tipoDeProducto.Id = new Random().Next(100000);
        entidades.Add(tipoDeProducto);
        return tipoDeProducto.Id;
    }

    public bool UpdateTipoDeProducto(TipoDeProducto tipoDeProducto)
    {

        var entidad = entidades.Where(o => o.Id == tipoDeProducto.Id).FirstOrDefault();
        if (entidad == null) return false;

        entidad.Descripcion = tipoDeProducto.Descripcion;
        entidad.Habilitado = tipoDeProducto.Habilitado;

        entidades.Add(tipoDeProducto);
        return true;
    }

    public bool DeleteTipoDeProducto(int ID)
    {
        var entidad = entidades.Where(o => o.Id == ID).FirstOrDefault();
        if (entidad == null) return false;
        entidades.Remove(entidad);
        return true;

    }

    public TipoDeProducto SelectTipoDeProducto(int ID)
  => entidades.Where(o => o.Id == ID && o.Habilitado == true).FirstOrDefault();


    public List<TipoDeProducto> SelectListTipoDeProducto() =>
        entidades.Where(o => o.Habilitado == true).ToList();



}

