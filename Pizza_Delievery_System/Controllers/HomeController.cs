using Microsoft.AspNetCore.Mvc;
using Pizza_Delievery_System.Models;
using System.Diagnostics;

namespace Pizza_Delievery_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly PizzaDBContext context;

        public HomeController(PizzaDBContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var product = this.context.Pizza.ToList().Take(3);

            return View(product);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
