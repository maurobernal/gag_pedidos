using FrontEnd.Interfaces;
using FrontEnd.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        public IPokemonService _pokemonService { get; private set; }

        private IProductService _productService;

        public HomeController(IPokemonService pokemonService, IProductService productService)
        {
            _pokemonService = pokemonService;
            _productService = productService;
        }

        public async Task<IActionResult> GetPokemon() => Json(await _pokemonService.GetPokemonList());
        public async Task<IActionResult> GetPokemonDetail(int ID) => Json(await _pokemonService.GetPokemonDetails(ID));


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Kendo()
        {
            return View();
        }


        public async Task<IActionResult> Grilla_Read([DataSourceRequest] DataSourceRequest request, ProductModel P)
        {
            var productos = await _productService.GetAll();
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

        //public async Task<IActionResult> Grilla_Destroy(ProductModel P)

        //{
        //    var productos = await _productService.Delete(P.Id);
        //    return Json(productos);
        //}


        public IActionResult GetItems()
        {
            var datos = new List<SelectListItem>();
            datos.Add(new SelectListItem()
            {
                Text = "Black",
                Value = "1"
            });
            datos.Add(new SelectListItem()
            {
                Text = "Orange",
                Value = "2"
            });
            datos.Add(new SelectListItem()
            {
                Text = "Grey",
                Value = "3"
            });

            return Json(datos);
        }
        public IActionResult Test() => View("Test");
        public IActionResult Test1() => PartialView("Test");
        public IActionResult Test3()
        {
            List<string> list = new List<string>();
            list.Add("1");
            list.Add("2");
            list.Add("3");

            ViewData["dato1"] = "Maxi";
            ViewData["Legajo"] = "12345";
            ViewData["fecha"] = new DateTime(2022, 02, 01);
            ViewData["list"] = list;

            return View("Test");
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
