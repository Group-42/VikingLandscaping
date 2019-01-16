using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VikingLandscaping.Models;

namespace VikingLandscaping.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Here you can write something about the business and their owners.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Here you can input some text to explain why people should contact you.";

            ContactFormModel contactFormModel;
            contactFormModel = new ContactFormModel();


            return View(contactFormModel);
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Våra tjänster";

            return View();
        }
    }
}