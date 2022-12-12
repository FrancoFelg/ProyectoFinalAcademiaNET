using Microsoft.AspNetCore.Mvc;
using MVC004.Datos;

namespace MVC004.Controllers
{
    public class EmpleadosController : Controller
    {
        EmpleadoDatos empleadoDatos=new EmpleadoDatos();
        public IActionResult Index()
        {
            var listaEmpleado= empleadoDatos.ListaEmpleados();
            return View(listaEmpleado);
        }
    }
}
