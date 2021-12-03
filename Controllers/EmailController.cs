using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Gmail model)
        {
            //MailMessage mail = new MailMessage(model.From, model.To);
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(model.To);
                mail.From = new MailAddress("shubhiigoel17@gmail.com");

                string resetCode = Guid.NewGuid().ToString();
                var verifyUrl = "/Account/ResetPassword/" + resetCode;
                var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

                var passwordResetLink = Url.Action("ResetPassword", "Email");
                mail.Subject = "Reset Password";
                mail.Body = link;
                mail.IsBodyHtml = false;


                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                NetworkCredential nc = new NetworkCredential("shubhiigoel17@gmail.com", "Sneha@17");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = nc;
                smtp.Send(mail);
                ViewBag.Message = "Mail has been sent successfully";
                return View();
            }
            else
            {
                return View();
            }
        }

        public ActionResult ResetPassword()
        {
            return View();
        }



     
    }
}