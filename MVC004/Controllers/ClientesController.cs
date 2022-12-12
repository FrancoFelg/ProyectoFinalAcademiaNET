using Microsoft.AspNetCore.Mvc;
using MVC004.Datos;

namespace MVC004.Controllers
{
    public class ClientesController : Controller
    {
        ClienteDatos clientedato=new ClienteDatos();
        public IActionResult Index()
        {
            var listaCliente = clientedato.ListaCliente();
            return View(listaCliente);
        }
    }
}
