using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GemeinschaftsBalkonWebApp01.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

         //C# attribut
        public ActionResult About()
        {
            ViewBag.Message = "News";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Unser Kontakt";

            return View();
        }
    }
}