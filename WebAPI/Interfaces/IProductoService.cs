

using WebAPI.DTOs;

namespace WebAPI.Services
{
    public interface IProductoService
    {
        int AddProducto(ProductoDTO producto);
        bool DeleteProducto(int ID);
        List<ProductoDTO> SelectListProducto();
        ProductoDTO SelectProducto(int ID);
        bool UpdateProducto(ProductoDTO producto);
    }
}