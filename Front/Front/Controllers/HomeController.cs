using Front.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Front.Controllers
{
    public class HomeController : Controller
    {

        private IPokemonService _pokemonService;

        public HomeController(IPokemonService pokemonService)
        => _pokemonService = pokemonService;


        public async Task<IActionResult> GetPokemon()
        => Json(await _pokemonService.GetPokemonList());

        public async Task<IActionResult> GetPokemonDetails(int ID)
      => Json(await _pokemonService.GetPokemonDetails(ID));


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            List<string> Lista = new List<string>();

            Lista.Add("1");
            Lista.Add("2");
            Lista.Add("3");
            Lista.Add("4");

            ViewData["dato1"] = "Mauro";
            ViewData["legajo"] = 23423;
            ViewData["fecha"] = new DateTime(2022,02,22);
            ViewData["lista"] = Lista;

            return  View("Test");
        }

        public IActionResult json()
        {

            List<string> list = new List<string>();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");

            return Json(list);

        }

   

        public IActionResult redirect()
        {
            return Redirect("http://google.com");
        }

        public IActionResult redirectTo()
        {
            return RedirectToAction("json");
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

        public IActionResult Kendo()
        {
            return View();
        }

        public IActionResult GetItems()
        {
            var Datos = new List<SelectListItem>();


            Datos.Add(new SelectListItem() {
                Text = "Black",
                Value = "1"
            });

            Datos.Add(new SelectListItem()
            {
                Text = "Orange",
                Value = "2"
            });
            Datos.Add(new SelectListItem()
            {
                Text = "Grey",
                Value = "3"
            });


            return Json(Datos);


        }
    }
}
