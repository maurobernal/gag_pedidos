using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Front.Controllers
{
    public class HomeController : Controller
    {
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
    }
}
