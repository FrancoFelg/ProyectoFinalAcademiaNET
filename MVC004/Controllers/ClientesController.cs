using Microsoft.AspNetCore.Mvc;
using MVC004.Datos;
using MVC004.Models;

namespace MVC004.Controllers
{
    public class ClientesController : Controller
    {
        ClienteDatos clienteDatos=new ClienteDatos();
        
        // visualizacion de la lista de clientes
        public IActionResult Index()
        {
            var listacliente = clienteDatos.ListaCliente();

            return View(listacliente);
        }

        public IActionResult RegCliente()
        {
            return View();  
        }

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

        public IActionResult ModCliente(int id)
        {
            var obclientes = clienteDatos.ObtenerCli(id);
            return View(obclientes);
        }

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

        public IActionResult DelCliente(int id)
        {
            var obclientes = clienteDatos.ObtenerCli(id);
            return View(obclientes);  

        }
        [HttpPost]
        public IActionResult DelCliente(Clientes obclientes)
        {
            var respuesta = clienteDatos.EliminarCli(obclientes.Id);
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
