using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC004.Datos;
using MVC004.Models;

namespace MVC004.Controllers
{
	public class ProductoRelProveedoresController : Controller
	{
        ProductoRelProveedoresDatos datos = new ProductoRelProveedoresDatos();

		public IActionResult Create()
		{
			var po = new ProductoRelProveedor();
			return View(po);
		}

		[HttpPost]
        public IActionResult Create(ProductoRelProveedor prod)
        {
            bool rta = datos.save(prod);
            if (rta)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public IActionResult ViewCliente(int id)
        {
            ProductoRelOrden prod = new ProductoRelOrden();
            ProductoRelProveedor prodProv = datos.getById(id);
            prod.productoRelProveedor = prodProv;
            
            return View(prod);
        }
    }
}
