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

        public IActionResult ModEmpleados(int id)
        {
            var obempleados = empleadoDatos.ObtenerEmp(id);
            return View();
        }

        [HttpPost]
        public IActionResult ModEmpleados(Empleados obempleados)
        {
            var respuesta = empleadoDatos.ModEmpleados(obempleados);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();

            }
        }

        public IActionResult DelEmpleados(int id)
        {
            var respuesta = empleadoDatos.DelEmpleado(id);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

    }
}
