using Microsoft.AspNetCore.Mvc;
using MVC004.Datos;
using MVC004.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace MVC004.Controllers

{

    [Authorize]
    public class HomeController : Controller
    {
        ProductoDatos productoDatos = new ProductoDatos();
        ProductoRelOrdenesDatos prodRelOrden = new ProductoRelOrdenesDatos();
        
        ProductoRelProveedoresDatos prodRelProv = new ProductoRelProveedoresDatos();
        

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var objLista = prodRelProv.getAllProducts();
            
            /*
            List<object> list = new List<object>();
            list.Add(currentUser);
            var obj = new ObjView(objLista, list);
            */

            return View(objLista);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}