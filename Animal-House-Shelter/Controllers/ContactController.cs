using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Animal_House_Shelter.Infrastructure;
using Animal_House_Shelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Animal_House_Shelter.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(
            [FromServices] IEmailSender emailSender,
            [FromServices] IConfiguration configuration,
            Contact contact)
        {
            emailSender.Post(
                subject: "Contact request",
                body: $"{contact.Name} {contact.LastName} ({contact.Email}) has sent you this message: {contact.Message}.",
                sender: contact.Email,
                recipients: configuration["AdminContact"]);
            return RedirectToAction(nameof(ThankYou));
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}