using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC004.Datos;
using MVC004.Models;

namespace MVC004.Controllers
{
    
    public class ClientesController : Controller
    {
        ClienteDatos clienteDatos=new ClienteDatos();

        [Authorize]
        // visualizacion de la lista de clientes
        public IActionResult Index()
        {
            var listacliente = clienteDatos.ListaCliente();

            return View(listacliente);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult RegCliente()
        {
            return View();  
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult RegCliente( Clientes obclientes)
        {
            var respuesta = clienteDatos.AgregarCli(obclientes);
            if (respuesta)
            {
                return RedirectToAction("Index");

            }
            else { return View(); }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult ModCliente(int id)
        {
            
            var obclientes = clienteDatos.ObtenerCli(id);
            return View(obclientes);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult ModCliente(Clientes obclientes)
        {
            var respuesta= clienteDatos.ModificarCli(obclientes);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();

            }
        }

        /*public IActionResult DelCliente(int id)
        {
            var obclientes = clienteDatos.ObtenerCli(id);
            return View(obclientes);  

        }*/
        [Authorize(Roles = "Admin")]
        public IActionResult DelCliente(int id)
        {
            var respuesta = clienteDatos.EliminarCli(id);
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
