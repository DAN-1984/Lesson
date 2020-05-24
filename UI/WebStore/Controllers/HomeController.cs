using Microsoft.AspNetCore.Mvc;
using System;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() 
        {
            ViewData["title"] = "Главная";
            return View(); 
        }

        public IActionResult Throw(string id) => throw new ApplicationException(id);

        public IActionResult SomeAction() => View();

        public IActionResult Error404() => View();

        public IActionResult Blog() => View();

        public IActionResult BlogSingle() => View();

        public IActionResult CheckOut() => View();

        public IActionResult ContactUs() => View();

    }
}