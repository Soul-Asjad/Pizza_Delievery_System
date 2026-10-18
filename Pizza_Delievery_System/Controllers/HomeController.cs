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

        public IActionResult Custom_pizza()
        {
            ViewBag.PizzaBase = this.context.PizzaBase.ToList();
            ViewBag.Sauce = this.context.Sauce.ToList();
            ViewBag.Cheese = this.context.Cheese.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Custom_Pizza(CustomPizza pizza)
        {
            var session = HttpContext.Session.GetInt32("User_ID");

            if (session == null)
            {
                return RedirectToAction("Login", "User");
            }

            pizza.UserID = session.Value;

            this.context.CustomPizza.Add(pizza);
            this.context.SaveChanges();

            int customid = pizza.CustomPizzaID;

            return RedirectToAction("AddtoCart","Cart", new
            {
                id = customid,
                quantity = 1
            });
        }
    }
}
