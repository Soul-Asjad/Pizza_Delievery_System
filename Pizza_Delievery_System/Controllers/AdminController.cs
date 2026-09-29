using Microsoft.AspNetCore.Mvc;
using Pizza_Delievery_System.Models;

namespace Pizza_Delievery_System.Controllers
{
    public class AdminController : Controller
    {
        private readonly PizzaDBContext context;

        public AdminController(PizzaDBContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login" , "User");
            }

            return View();
        }
    }
}
