using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace ProyectoGestion.Web.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index() { return View(); }
        public ActionResult Home() { return View(); }
        public ActionResult Login() { return View(); }
        public ActionResult register() { return View(); }
        public ActionResult user() { return View(); }
        public ActionResult error() { return View(); }
        public ActionResult admin() { return View(); }
    }
}