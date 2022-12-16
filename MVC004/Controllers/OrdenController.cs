using Microsoft.AspNetCore.Mvc;
using MVC004.Datos;
using MVC004.Models;
using System.Data.SqlClient;
using System.Text;

namespace MVC004.Controllers
{
    public class OrdenController : Controller
    {
        OrdenDatos ordenDatos = new OrdenDatos();
        public IActionResult Index()
        {
            return View(ordenDatos.getAllOrdenes());
        }

        public IActionResult Create()
        {
            Orden orden = new Orden();                       
            return View(orden);
        }

        [HttpPost]
        public IActionResult Create(Orden orden)
        {
            
            bool rta = ordenDatos.save(orden);
            if (rta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(); //error view
            }
            
        }
       
        public IActionResult Eliminar(int id)
        {            
            bool rta = ordenDatos.delete(id);
            if (rta)
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
            var obj = ordenDatos.getById(id);
            System.Diagnostics.Debug.WriteLine(""+ obj.fechaAlta + " " + obj.fechaEntrega);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Editar(Orden orden)
        {
            var rta = ordenDatos.edit(orden);
            if(rta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Error al editar");
                return View();
            }
        }

    }
}
