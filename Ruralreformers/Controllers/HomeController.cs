using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ruralreformers.Helper;
using Ruralreformers.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Ruralreformers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("rural-reformers/donate")]
        [HttpGet]
        public IActionResult Donate()
        {
            return View();
        }

        [Route("rural-reformers/join-as-volunteer")]
        [HttpGet]
        public IActionResult JoinAsVolunteer()
        {
            return View();
        }

        [Route("rural-reformers/join-as-volunteer")]
        [HttpPost]
        public IActionResult JoinAsVolunteer(Registeration registeration)
        {
            var cloudHelper = new CloudIntegrationHelper();
            var result = cloudHelper.SaveUserInformationToS3(registeration);
            ViewBag.SuccessMessage = result;
            return View();
        }

        [Route("rural-reformers/faq")]
        [HttpGet]
        public IActionResult Faq()
        {
            return View();
        }

        [Route("rural-reformers/contact-us")]
        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        [Route("rural-reformers/contact-us")]
        [HttpPost]
        public IActionResult ContactUs(ContactUs contactUs)
        {
            //var fromAddress = new MailAddress(contactUs.FromEmail, contactUs.FromEmail);
            //var toAddress = new MailAddress(contactUs.ToEmail, "Rural-Reforms");
            //const string fromPassword = "fromPassword";
            //const string subject = "Subject";
            //const string body = "Body";

            //var smtp = new SmtpClient
            //{
            //    Host = "smtp.gmail.com",
            //    Port = 587,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            //};
            //using (var message = new MailMessage(fromAddress, toAddress)
            //{
            //    Subject = subject,
            //    Body = body
            //})
            //{
            //    smtp.Send(message);
            //}

            return View();
        }

        [Route("rural-reformers/error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
