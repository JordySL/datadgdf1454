using Microsoft.AspNetCore.Mvc;
using ProyectoGestion.Business;
using ProyectoGestion.Models.EntityForm;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProyectoGestion.Web.Controllers
{
    public class ModelsViewController : Controller
    {
        private IUserAccountPhotoBusiness _useraccountphotoBusiness;
        public ModelsViewController(IUserAccountPhotoBusiness useraccountphotoBusiness)
        {
            _useraccountphotoBusiness = useraccountphotoBusiness;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AngularFormBasic()
        {
            return View();
        }
        public IActionResult AngularTable()
        {
            return View();
        }
        public IActionResult AngularEnviarData()
        {
            var data = _useraccountphotoBusiness.GetAllUserAccountPhoto();
            return View(Json(data));
        }
        //Razor Page
        public IActionResult RazorListar()
        {
            var data = _useraccountphotoBusiness.GetAllUserAccountPhoto();
            return View(data);
        }
        //Json Page
        [HttpPost]
        public JsonResult JsonListar()
        {
            var data = _useraccountphotoBusiness.GetAllUserAccountPhoto();
            return Json(data);
        }
        public PartialViewResult Edit()
        {
            return PartialView("_Edit");
        }
        //Json by AngularJs Page
        public IActionResult AngularListar()
        {
            var data = _useraccountphotoBusiness.GetAllUserAccountPhoto();
            return View(data);
        }
        public IActionResult Modals()
        {
            return View("Modals");
        }
        public string Create(UserAccountPhoto UserAccountPhoto)
        {
            var data = _useraccountphotoBusiness.InsertUserAccountPhoto(UserAccountPhoto);
            string data2 = "asd";
            return data2;
        }
        public IActionResult Edit(int id)
        {
            var entidad = _useraccountphotoBusiness.GetUserAccountPhoto(id);
            return View(entidad);
        }
        [HttpPost]
        public IActionResult Edit(UserAccountPhoto UserAccountPhoto)
        {
            _useraccountphotoBusiness.UpdateUserAccountPhoto(UserAccountPhoto);
            return View(UserAccountPhoto);
        }
        public IActionResult Delete(int id)
        {
            var delete = new UserAccountPhoto { ID = id };
            var data = _useraccountphotoBusiness.DeleteUserAccountPhoto(delete);
            return View("Index");
        }
        public IActionResult File(){ return View(); }
        public IActionResult googlemap() { return View(); }
        public IActionResult variacion() { return View(); }
    }
}



