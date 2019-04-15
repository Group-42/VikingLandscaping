using System.Collections.Generic;
using System.Web.Mvc;
using VikingLandscaping.Models;
using System.Net.Mail;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Diagnostics;
using System;
using System.IO;
using Newtonsoft.Json.Linq;

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
            ViewBag.Message = "Vårt team";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Vänligen meddela oss om du har några frågor, så kommer vi att svara på lämpligt sätt.";

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
                message.To.Add(new MailAddress("thedestroyingdestroyer@gmail.com")); //TODO replace with company email
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
            var services = JsonConvert.DeserializeObject<List<ServiceModel>>(System.IO.File.ReadAllText(Server.MapPath("~/Data/ServiceData.json"), Encoding.UTF8));

            return View(services);
        }

        public ActionResult Details(ServiceModel m)
        {
            ViewBag.Message = "Details";
            return View(m);
        }
    }
}