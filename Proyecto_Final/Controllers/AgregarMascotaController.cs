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

        public IActionResult AgregarMascota(Mascota agregarMascota)
        {
            _Mascota.Add(agregarMascota);
            return RedirectToAction("Index.cshtml");
        }
    }
}
