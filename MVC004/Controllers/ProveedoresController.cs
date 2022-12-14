using Microsoft.AspNetCore.Mvc;
using MVC004.Datos;
using MVC004.Models;

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

        public IActionResult RegistroProv()
        {
            return View();
        }

        [HttpPost]

        public IActionResult RegistroProv(Proveedores obProveedores)

        {

            var respuesta = proveedorDatos.AgregarProv(obProveedores);
            if(respuesta){
                return RedirectToAction("Index");

            }
            else { return View(); }
           
        }

        public IActionResult ModificarProv(int id)
        {
            var obProveedores=proveedorDatos.ObtenerProv(id);   
            return View(obProveedores);
        }

        [HttpPost]
        public IActionResult ModificarProv(Proveedores obProveedores)
        {
            var respuesta = proveedorDatos.ModificarProv(obProveedores);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();

            }
            
        }

        public IActionResult EliminarProv(int id)
        {
            var obProveedores = proveedorDatos.ObtenerProv(id);
            return View(obProveedores);
        }

        [HttpPost]
        public IActionResult EliminarProv(Proveedores obProveedores)
        {
            var respuesta = proveedorDatos.EliminarProv(obProveedores.id);
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
