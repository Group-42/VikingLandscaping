﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VikingLandscaping.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Phone: {2}</p><p>Message:</p><p>{3}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("thedestroyingdestroyer@gmail.com")); //replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.Name, model.Email, model.Phone, model.Message);
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Våra tjänster";

            return View();
        }
    }
}