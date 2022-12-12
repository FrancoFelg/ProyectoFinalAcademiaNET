using Microsoft.AspNetCore.Mvc;
using MVC004.Datos;

namespace MVC004.Controllers
{
    public class ProveedoresController : Controller
    {
        ProveedorDatos proveedorDatos=new ProveedorDatos();
        public IActionResult Index()
        {
            var listaprove = proveedorDatos.ListaProv();
            return View(listaprove);
        }
    }
}
