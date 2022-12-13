using Microsoft.AspNetCore.Mvc;
using MVC004.Models;
using MVC004.Datos;

namespace MVC004.Controllers
{
    public class ProductController : Controller
    {
        ProductoDatos productoDatos = new ProductoDatos();
        public IActionResult Index()
        {
            var producto = new Producto();
            return View(producto);
        }

        [HttpPost]
        public IActionResult Guardar(Producto producto)
        {
            //System.Diagnostics.Debug.WriteLine("La respuesta fue : " + producto.id + producto.nombre );
            var respuesta = productoDatos.save(producto);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        public IActionResult Editar(int id)
        {
            var producto = productoDatos.getById(id);
            return View(producto);
        }

        [HttpPost]
        public IActionResult Editar(Producto producto)
        {
            
            var respuesta = productoDatos.edit(producto);
            System.Diagnostics.Debug.WriteLine("UPD_" + respuesta);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Tabla()
        {
            var objLista = productoDatos.getAllProducts();
            return View(objLista);
        }

        public IActionResult Eliminar(int id)
        {
            var respuesta = productoDatos.deleteById(id);
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
