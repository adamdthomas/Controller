using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HalloweenController_v0._0._1.DAL;


namespace HalloweenController_v0._0._1.Controllers
{
    public class HomeController : Controller
    {
        int i = 0;

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
            i++;
            ViewBag.Message = i.ToString();
            //ViewBag.Message = "Star Manager";

            return View();
        }

        public ActionResult AddOne()
        {
            MyMethods.AddStars("Gabriel",1);
            return View("StarManager");
        }


        public ActionResult MyStars()
        {

            ViewBag.Message = "My Stars";

            return View();
        }
    }
}