using Microsoft.AspNetCore.Mvc;
using MVC004.Datos;
using MVC004.Models;

namespace MVC004.Controllers
{
    public class ProveedoresController : Controller
    {
        ProveedorDatos proveedorDatos=new ProveedorDatos();

        // este metodo es para la visualizacion de la lista de proveedores registrados
        public IActionResult Index()
        {
            var listaprove = proveedorDatos.ListaProv();
            return View(listaprove);
        }

        // este metodo es para cargar un nuevo proveedor
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

        /*public IActionResult EliminarProv(int id)
        {
            var obProveedores = proveedorDatos.ObtenerProv(id);
            return View(obProveedores);
        }*/

        
        public IActionResult EliminarProv(int id)
        {
            var respuesta = proveedorDatos.EliminarProv(id);
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
