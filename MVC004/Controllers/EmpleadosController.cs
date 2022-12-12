using Microsoft.AspNetCore.Mvc;

namespace MVC004.Controllers
{
    public class EmpleadosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
