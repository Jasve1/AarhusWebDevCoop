using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Core.Models;
using AarhusWebDevCoop.ViewModels;
using System.Net.Mail;

namespace AarhusWebDevCoop.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {
        public ActionResult Index()
        {
            return PartialView("Partials/ContactForm", new ContactForm());
        }

        [HttpPost]
        public ActionResult HandleFormSubmit(ContactForm model)
        {
            if (!ModelState.IsValid) { return CurrentUmbracoPage(); }

            //MailMessage message = new MailMessage();
            //message.To.Add("eaajasv@students.eaaa.dk");
            //message.Subject = model.Subject;
            //message.From = new MailAddress(model.Email, model.Name);
            //message.Body = model.Message;

            //using(SmtpClient smtp = new SmtpClient())
            //{
            //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    smtp.UseDefaultCredentials = false;
            //    smtp.EnableSsl = true;
            //    smtp.Host = "smtp.gmail.com";
            //    smtp.Port = 587;
            //    smtp.Credentials = new System.Net.NetworkCredential("jakobkilias0311@gmail.com", "rgtipqsvyjeodqpe");

            //    smtp.Send(message);
            //}

            IContent msg = Services.ContentService.CreateContent(model.Subject, CurrentPage.Id, "message");
            msg.SetValue("messageName", model.Name);
            msg.SetValue("email", model.Email);
            msg.SetValue("subject", model.Subject);
            msg.SetValue("messageContent", model.Message);

            Services.ContentService.Save(msg);

            TempData["succes"] = true;
            return RedirectToCurrentUmbracoPage();
        }
    }
}