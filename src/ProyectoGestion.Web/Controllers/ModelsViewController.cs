using Microsoft.AspNetCore.Mvc;
using ProyectoGestion.Business;


namespace ProyectoGestion.Web.Controllers
{
    public class ModelsViewController : Controller
    {
        private IUserAccountPhotoBusiness _useraccountphotoBusiness;
        public ModelsViewController(IUserAccountPhotoBusiness useraccountphotoBusiness)
        {
            _useraccountphotoBusiness = useraccountphotoBusiness;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AngularFormBasic()
        {
            return View();
        }
        public ActionResult AngularTable()
        {
            return View();
        }
        public ActionResult AngularEnviarData()
        {
            return View();
        }
        //Razor Page
        public ActionResult RazorListar()
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
        public ActionResult AngularListar()
        {
            var data = _useraccountphotoBusiness.GetAllUserAccountPhoto();
            return View(data);
        }
        public ActionResult Modals()
        {
            return View("Modals");
        }
    }
}



