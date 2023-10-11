using Microsoft.AspNetCore.Mvc;
using Proyecto_Final.Models;

namespace Proyecto_Final.Controllers
{
    public class AgregarController : Controller
    {
        public IActionResult AgregarMascota()
        {
            return View();
        }
    }
}
