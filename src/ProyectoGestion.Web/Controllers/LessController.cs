using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace ProyectoGestion.Web.Controllers
{
    public class LessController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}