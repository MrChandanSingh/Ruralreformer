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
using System.Web;

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
            ViewBag.SuccessMessage = SendMail(registeration);
            return View();
        }

        private bool SendMail(Registeration registeration)
        {
            try
            {
                var fromAddress = new MailAddress("Ruralreformers@gmail.com");
                var toAddress = new MailAddress("Ruralreformers@gmail.com");
                const string fromPassword = "Kindness080#";
                const string subject = "Join As Volunteer";
                string body = $"<body><h3>Hi Team,</h3></br></br><p>Email: {registeration.Email}</p>" +
                    $"<p>Name: {registeration.Name}</p><p>Phone: {registeration.PhoneNumber}</p>" +
                    $"<p>Occupation: {registeration.Occupation}</p>" +
                    $"<p>Place: {registeration.Place}</p></br>" +
                    $"<p>Tell me about yourself: {registeration.YourSelf}</p>" +
                    $"<p>Why you want to volunteer?: {registeration.WhyWantToJoin}</p>" +
                    $"<p>Thanks & Regards,</p>" +
                    $"<p>Rural-Reformera</p></body>";
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    message.IsBodyHtml = true;
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
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

        [Route("rural-reformers/our-team")]
        [HttpGet]
        public IActionResult OurTeam()
        {
            return View();
        }

        [Route("rural-reformers/contact-us")]
        [HttpPost]
        public IActionResult ContactUs(ContactUs contactUs)
        {
            var fromAddress = new MailAddress("Ruralreformers@gmail.com");
            var toAddress = new MailAddress("Ruralreformers@gmail.com");
            const string fromPassword = "Kindness080#";
            const string subject = "Contact Us";
            string body = $"<body><h3>Hi Team,</h3></br></br><p>Email: {contactUs.FromEmail}</p>" +
                $"<p>Message: {contactUs.Message}</p>" +
                $"<p>Thanks & Regards,</p>" +
                $"<p>Mail: {contactUs.FromEmail}</p></body>";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                message.IsBodyHtml = true;
                smtp.Send(message);
            }

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
