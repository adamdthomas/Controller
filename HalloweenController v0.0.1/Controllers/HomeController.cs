using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HalloweenController_v0._0._1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["DisplayMessage"] = false;
            return View();
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {

            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult StarManager()
        {

            ViewBag.Message = "Star Manager";

            return View();
        }


        public ActionResult MyStars()
        {

            ViewBag.Message = "My Stars";

            return View();
        }
    }
}