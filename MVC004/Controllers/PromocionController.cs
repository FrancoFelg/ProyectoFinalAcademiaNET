using Microsoft.AspNetCore.Mvc;
using MVC004.Datos;
using MVC004.Models;

namespace MVC004.Controllers
{
    public class PromocionController : Controller
    {
        PromocionDatos pd = new PromocionDatos();
    public IActionResult Index()
    {
        return View(pd.getAll());
    }

    public IActionResult Guardar()
    {
        return View(new Promocion());
    }

    [HttpPost]
    public IActionResult Guardar(Promocion promocion)
    {
        var rta = pd.save(promocion);
        if (rta)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
    }

    [HttpPost]
    public IActionResult Editar(Promocion promocion)
    {
        var rta = pd.edit(promocion);
        if (rta)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
    }

    public IActionResult Eliminar(int id)
    {
        var rta = pd.delete(id);
        if (rta)
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
