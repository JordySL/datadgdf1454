using Microsoft.AspNetCore.Mvc;
using ProyectoGestion.Business;
using System.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoGestion.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserBusiness _userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        public IActionResult Index()
        {
            var listado = _userBusiness.GetUsers().ToList();
            return View(listado);
        }
        public IActionResult Login()
        {
            var listado = _userBusiness.GetUsers().ToList();
            return View(listado);
        }
        [HttpPost]
        public IActionResult Autenticacion(string nombre,string clave)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(clave)) return RedirectToAction("Login");
            var auten = _userBusiness.Autenticacion(nombre, clave);
            if (auten.Count() > 0) return View("Bienvenida",auten);
            return RedirectToAction("Login");
        }
    }
}
