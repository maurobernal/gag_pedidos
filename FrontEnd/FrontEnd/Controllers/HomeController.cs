using FrontEnd.Interfaces;
using FrontEnd.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;


namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {

        private IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Kendo()
        {
            return View();
        }

        public async Task<IActionResult> Grilla_Read([DataSourceRequest] DataSourceRequest request, ProductModel P, string option)
        {
            var productos = await _productService.GetAll(option);
            return Json(productos.ToDataSourceResult(request));
        }

        public async Task<IActionResult> Grilla_Create(ProductModel P)
        {
            var productos = await _productService.Add(P);
            return Json(productos);
        }

        public async Task<IActionResult> Grilla_Update(ProductModel P)

        {
            var productos = await _productService.Update(P);
            return Json(productos);
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }


        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
