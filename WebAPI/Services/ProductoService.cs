using WebAPI.Entities;
namespace WebAPI.Services;

public class ProductoService
{
    public ProductoService()
    {
        entidades = new();
    }
    public List<Producto> entidades { get; set; }
    public int AddProducto(Producto Producto)
    {
        Producto.Id = new Random().Next(100000);
        entidades.Add(Producto);
        return Producto.Id;
    }

    public bool UpdateProducto(Producto Producto) {

        var entidad = entidades.Where(o => o.Id == Producto.Id ).FirstOrDefault();
        if (entidad == null) return false;

        entidad.Descripcion = Producto.Descripcion;
        entidad.Habilitado = Producto.Habilitado;

        entidades.Add(Producto);
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
