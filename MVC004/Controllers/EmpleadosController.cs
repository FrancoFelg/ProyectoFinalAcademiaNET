using Microsoft.AspNetCore.Mvc;
using MVC004.Datos;
using MVC004.Models;

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

        public IActionResult RegEmpleados()
        {
            return View();  
        }

        [HttpPost]
        public IActionResult RegEmpleados(Empleados obempleados)
        {
            var respuesta = empleadoDatos.RegEmpleados(obempleados);
            if (respuesta)
            {
                return RedirectToAction("Index");

            }
            else { return View(); }

        }
    }
}
