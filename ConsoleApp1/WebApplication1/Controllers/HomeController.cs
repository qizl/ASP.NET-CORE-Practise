using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _service;

        public HomeController(IUserService service)
        {
            this._service = service;
        }

        public IActionResult Index()
        {
            ViewData["Hello"] = this._service.SayHello();
            ViewBag.A = "hahaha~";

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
