using Front.Interfaces;
using Front.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{
    public class APIController : Controller
    {
        private IOrigenService _origenService;
        private IProductoService _productoService;
        private ITipoDeProductoService _tipoDeProductoService;

        public APIController(IOrigenService origenService, IProductoService productoService, ITipoDeProductoService tipoDeProductoService)
        { 
            _origenService = origenService;
            _productoService = productoService;
            _tipoDeProductoService = tipoDeProductoService;
        }

        //Origen
        public async Task<IActionResult> GetAllOrigen([DataSourceRequest] DataSourceRequest request, OrigenModels O)
        {
            var origen = await _origenService.GetAll();
            return Json(origen.ToDataSourceResult(request));
        }

        public async Task<IActionResult> GetOrigen(int id)
        => Json(await _origenService.Get(id));


        public async Task<IActionResult> EditOrigen(OrigenModels O)
        {
            return Json(await _origenService.Edit(O));
        }

        
        public async Task DeleteOrigen(int id)
        { 
            await _origenService.Delete(id);

        }

        public async Task<IActionResult> AddOrigen(OrigenModels O)
        {  

            return Json(await _origenService.Add(O));

        }

        public IActionResult CrudOrigen() => View();

        //Producto
        public async Task<IActionResult> GetAllProducto([DataSourceRequest] DataSourceRequest request, ProductoModels P)
        {
            var producto = await _productoService.GetAll();
            return Json(producto.ToDataSourceResult(request));
        }

        public async Task<IActionResult> GetProducto(int id)
        => Json(await _productoService.Get(id));


        public async Task<IActionResult> EditProducto(ProductoModels P)
        {
            return Json(await _productoService.Edit(P));
        }


        public async Task DeleteProducto(int id)
        {
            await _productoService.Delete(id);

        }

        public async Task<IActionResult> AddProducto(ProductoModels P)
        {

            return Json(await _productoService.Add(P));

        }

        public IActionResult CrudProducto() => View();

        //TipoDeProducto
        public async Task<IActionResult> GetAllTipoDeProducto([DataSourceRequest] DataSourceRequest request, TipoDeProductoModels T)
        {
            var tipoDeProductos = await _tipoDeProductoService.GetAll();
            return Json(tipoDeProductos.ToDataSourceResult(request));
        }

        public async Task<IActionResult> GetTipoDeProducto(int id)
        => Json(await _tipoDeProductoService.Get(id));


        public async Task<IActionResult> EditTipoDeProducto(TipoDeProductoModels T)
        {
            return Json(await _tipoDeProductoService.Edit(T));
        }


        public async Task DeleteTipoDeProducto(int id)
        {
            await _tipoDeProductoService.Delete(id);

        }

        public async Task<IActionResult> AddTipoDeProducto(TipoDeProductoModels T)
        {

            return Json(await _tipoDeProductoService.Add(T));

        }

        public IActionResult CrudTipoDeProducto() => View();



    }
}
