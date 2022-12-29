using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC004.Datos;
using MVC004.Models;

namespace MVC004.Controllers
{
    public class EmpleadosController : Controller
    {
        EmpleadoDatos empleadoDatos=new EmpleadoDatos();
        [Authorize]

        public IActionResult Index()
        {
            var listaEmpleado= empleadoDatos.ListaEmpleados();
            return View(listaEmpleado);
        }
        [Authorize(Roles = "Admin")]

        public IActionResult RegEmpleados()
        {
            return View();  
        }
        [Authorize(Roles = "Admin")]

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
        [Authorize(Roles = "Admin")]

        public IActionResult ModEmpleados(int id)
        {
            var obempleados = empleadoDatos.ObtenerEmp(id);
            return View(obempleados);
        }
        [Authorize(Roles = "Admin")]

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
        [Authorize(Roles = "Admin")]

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
