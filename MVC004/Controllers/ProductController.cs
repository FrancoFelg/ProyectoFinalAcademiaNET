using Microsoft.AspNetCore.Mvc;
using MVC004.Datos;

namespace MVC004.Controllers
{
    public class ProductController : Controller
    {
        ProductoDatos productoDatos = new ProductoDatos();
        public IActionResult Index()
        {
            var objLista = productoDatos.getAllProducts();
            return View(objLista);
        }
    }
}
