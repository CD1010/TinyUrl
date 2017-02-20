using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TinyUrl.Controllers
{
    public class HomeController : Controller
    {
      

        public ActionResult About()
        {
            ViewBag.Message = "An application which generates tiny urls";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Chris DePalma";

            return View();
        }
    }
}