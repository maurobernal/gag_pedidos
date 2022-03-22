using WebAPI.Entities;
namespace WebAPI.Services;

public class TipoProductoService
{
    public TipoProductoService()
    {
        entidades = new();
    }

    public List<Origen> entidades { get; set; }
    public int AddTipoProducto(Origen tipo_producto)
    {
        tipo_producto.Id = new Random().Next(100000);
        entidades.Add(tipo_producto);
        return tipo_producto.Id;
    }

    public bool UpdateTipoProducto(Origen tipo_producto)
    {

        var entidad = entidades.Where(o => o.Id == tipo_producto.Id).FirstOrDefault();
        if (entidad == null) return false;

        entidad.Descripcion = tipo_producto.Descripcion;
        entidad.Habilitado = tipo_producto.Habilitado;

        entidades.Add(tipo_producto);
        return true;
    }

    public bool DeleteTipoProducto(int ID)
    {
        var entidad = entidades.Where(w => w.Id == ID).FirstOrDefault();
        if (entidad == null) return false;
        entidades.Remove(entidad);
        return true;

    }

    public Origen SelectTipoProducto(int ID) => entidades.FirstOrDefault(o => o.Id == ID && o.Habilitado);


    public List<Origen> SelectListTipoProducto() =>
        entidades.Where(o => o.Habilitado == true).ToList();



}
