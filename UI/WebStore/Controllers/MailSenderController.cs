using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.ViewModels;
using WebStore.Infrastructure.MailSender;

namespace WebStore.Controllers
{
    public class MailSenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> MailSend(MailViewModel mail)
        {
            await SendMail.SendEmailAsync(mail).ConfigureAwait(false);
            return RedirectToAction(nameof(MailSender));
        }

        public IActionResult MailSender()
        {
            return View();
        }
    }
}