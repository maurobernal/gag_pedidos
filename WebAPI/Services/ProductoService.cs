using WebAPI.Entities;
using WebAPI.DTOs;
using WebAPI.Infrastructure;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace WebAPI.Services;

public class ProductoService : IProductoService
{
    private readonly AppDBContext _conexion;
    private readonly IMapper _mapper;
    public ProductoService(IMapper mapper)
    {
        _conexion = new AppDBContext();
        _mapper = mapper;
    }
    public int AddProducto(ProductoDTO producto)
    {
        var O = _mapper.Map<Producto>(producto);

        _conexion.Add(O);
        _conexion.SaveChanges();
        return producto.Id;
    }

    public bool UpdateProducto(ProductoDTO producto)
    {

        var entidad = _conexion.Productos.Where(o => o.Id == producto.Id).FirstOrDefault();
        if (entidad == null) return false;

        var O = _mapper.Map<Producto>(producto);

        _conexion.Add(O);
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

    public ProductoDTO SelectProducto(int ID)
  => _conexion.Productos.Where(o => o.Id == ID && o.Habilitado == true).ProjectTo<ProductoDTO>(_mapper.ConfigurationProvider).FirstOrDefault();


    public List<ProductoDTO> SelectListProducto() 
    {

        var List_O = _conexion.Origenes.Where(o => o.Habilitado == true).ToList();

        return _mapper.Map<List<ProductoDTO>>(List_O);
    }
        

}
