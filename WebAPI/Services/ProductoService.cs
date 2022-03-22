using WebAPI.Entities;
namespace WebAPI.Services;

public class ProductoService
{
    public ProductoService()
    {
        entidades = new();
    }
    public List<Producto> entidades { get; set; }
    public int AddProducto(Producto producto)
    {
        producto.Id = new Random().Next(100000);
        entidades.Add(producto);
        return producto.Id;
    }

    public bool UpdateProducto(Producto producto)
    {

        var entidad = entidades.Where(o => o.Id == producto.Id).FirstOrDefault();
        if (entidad == null) return false;

        entidad.Descripcion = producto.Descripcion;
        entidad.Habilitado = producto.Habilitado;

        entidades.Add(producto);
        return true;
    }

    public bool DeleteProducto(int ID)
    {
        var entidad = entidades.Where(o => o.Id == ID).FirstOrDefault();
        if (entidad == null) return false;
        entidades.Remove(entidad);
        return true;

    }

    public Producto SelectProducto(int ID)
  => entidades.Where(o => o.Id == ID && o.Habilitado == true).FirstOrDefault();


    public List<Producto> SelectListProducto() =>
        entidades.Where(o => o.Habilitado == true).ToList();



}
