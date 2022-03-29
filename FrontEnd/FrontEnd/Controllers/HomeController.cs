using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Kendo()
        {
            return View();
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
