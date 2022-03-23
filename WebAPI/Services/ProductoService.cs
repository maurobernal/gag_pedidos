using WebAPI.Entities;
using WebAPI.Infrastructure;
namespace WebAPI.Services;

public class ProductoService
{
    private readonly AppDBContext _conexion;
    public ProductoService()
    {
        _conexion = new AppDBContext();
    }
    public int AddProducto(Producto producto)
    {
        _conexion.Add(producto);
        _conexion.SaveChanges();
        return producto.Id;
    }

    public bool UpdateProducto(Producto producto)
    {

        var entidad = _conexion.Productos.Where(o => o.Id == producto.Id).FirstOrDefault();
        if (entidad == null) return false;

        entidad.Descripcion = producto.Descripcion;
        entidad.Habilitado = producto.Habilitado;
        _conexion.Add(producto);
        _conexion.SaveChanges();
        return true;
    }

    public bool DeleteProducto(int ID)
    {
        var entidad = _conexion.Productos.Where(o => o.Id == ID).FirstOrDefault();
        if (entidad == null) return false;
        _conexion.Remove(entidad);
        _conexion.SaveChanges();
        return true;

    }

    public Producto SelectProducto(int ID)
  => _conexion.Productos.Where(o => o.Id == ID && o.Habilitado == true).FirstOrDefault();


    public List<Producto> SelectListProducto() =>
        _conexion.Productos.Where(o => o.Habilitado == true).ToList();



}
