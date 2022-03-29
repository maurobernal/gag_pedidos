using Microsoft.AspNetCore.Mvc;
using FrontEnd.Models;

namespace FrontEnd.Controllers;

public class UserController : Controller
{
    public IActionResult Profile(int id) => View(UserModel.SearchUser(id));

    public IActionResult Edit(int id) => View(UserModel.SearchUser(id));

    [HttpPost]
    public IActionResult Edit(string Tbx1, string Tbx2, string Tbx3) => View();
}
