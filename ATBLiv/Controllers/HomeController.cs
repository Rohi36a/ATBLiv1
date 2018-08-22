using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ATBLiv.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }


        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Partners()
        {
            return View();
        }


        public ActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> email(FormCollection form)
        {
            string message = string.Empty;

            var name = form["sname"];
            var email = form["semail"];
            var messages = form["smessage"];
            var phone = form["sphone"];
            var x = await SendEmail(name, email, messages, phone);
            if (x == "sent")
                TempData["msg"] = "<script>alert('Your Message Was Sent Successfully');</script>";
            else
                TempData["msg"] = "<script>alert('Something Went Wrong');</script>";
            return RedirectToAction("Home");
        }
        private async Task<string> SendEmail(string name, string email, string messages, string phone)
        {


            var message = new MailMessage();
            var body = "<p>Email From: {0} ({1})</p><p>Phone:</p><p>{2}</p><p>Message:</p><p>{3}</p>";


            message.To.Add(new MailAddress("rohit36a@gmail.com")); // replace with receiver's email id   
            message.To.Add(new MailAddress("shailendra176@gmail.com"));
            message.From = new MailAddress(email); // replace with sender's email id   
            message.Subject = "Message From " + name;
            message.Body = string.Format(body, email, name, phone, messages);
            message.IsBodyHtml = true;


            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "varma36a@gmail.com", // replace with sender's email id   
                    Password = "sai##1886" // replace with password   
                };
                smtp.Credentials = credential;

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
                return "sent";

            }
        }
    }
}