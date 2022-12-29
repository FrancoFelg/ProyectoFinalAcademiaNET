using Microsoft.AspNetCore.Mvc;
using MVC004.Datos;
using MVC004.Models;

namespace MVC004.Controllers
{
    public class ProductoRelOrdenesController : Controller
    {

        ProductoRelOrdenesDatos pRoD = new ProductoRelOrdenesDatos();

        public IActionResult CrearOrden()
        {
            ProductoRelOrden po = new ProductoRelOrden();
            return View(po);
        }

        [HttpPost]
        public IActionResult Create(ProductoRelOrden pro)
        {
            bool rta = pRoD.save(pro);
            if (rta)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(); //error view
            }
        }
    }
}
