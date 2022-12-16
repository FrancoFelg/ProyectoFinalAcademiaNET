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

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var objLista = productoDatos.getAllProducts();
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