using Microsoft.AspNetCore.Mvc;
using Front.Models;

namespace Front.Controllers

{
    public class UsuarioController : Controller
    {

        public IActionResult perfil(int id)
        {

            //UsuarioModels U = new UsuarioModels();
            //U.Apellido = "Roza";
            //U.Nombre = "Joaquin";
            //U.FechaNac = new DateOnly(2001,01,21);
            //U.Id = 1;
            //U.Legajo = 3245;
            ////1
            //ViewData["perfil"] = U;
            ////2
            //ViewBag.Usuario = U;

            return View(UsuarioModels.BuscarUsuario(id));
        }


        [HttpGet]
        public IActionResult Editar(int id)
        { 
            return View(UsuarioModels.BuscarUsuario(id));
        }

        [HttpPost]
        public IActionResult Editar(string tbx1, string tbx2, string tbx3)
        {
            return View();
        }

    }
}
