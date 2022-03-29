
using WebAPI.DTOs;

namespace WebAPI.Services
{
    public interface ITipoDeProductoService
    {
        int AddTipoDeProducto(TipoDeProductoDTO tipoDeProducto);
        bool DeleteTipoDeProducto(int ID);
        List<TipoDeProductoDTO> SelectListTipoDeProducto();
        TipoDeProductoDTO SelectTipoDeProducto(int ID);
        bool UpdateTipoDeProducto(TipoDeProductoDTO tipoDeProducto);
    }
}