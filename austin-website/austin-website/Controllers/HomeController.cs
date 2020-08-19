using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace austin_website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void ContactSubmit(string name, string email, string message)
        {
            var smtpClient = new SmtpClient()
            {
                Port = 587,
                EnableSsl = true,
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(email),
                Subject = "austindelarosa.com message",
                Body = $"<h4>New message from {name} {email}</h4>" +
                       $"<p>{message}<p>" +
                       $"Sent: {DateTime.Now.ToString(CultureInfo.CurrentCulture)}",
                IsBodyHtml = true,
            };
            mailMessage.To.Add("austin.delarosa@gmail.com");
            smtpClient.Send(mailMessage);
        }
        
    }
}