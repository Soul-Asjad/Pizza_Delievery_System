using Microsoft.AspNetCore.Mvc;
using Pizza_Delievery_System.Models;

namespace Pizza_Delievery_System.Controllers
{
    public class UserController : Controller
    {
        private readonly PizzaDBContext context;

        public UserController(PizzaDBContext context)
        {
            this.context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User data)
        {

            var user = this.context.User.FirstOrDefault(x => x.Email == data.Email);

            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    TempData["Error"] = "Email already exists.";
                    return View();
                }

                data.Password = BCrypt.Net.BCrypt.HashPassword(data.Password);

                this.context.User.Add(data);
                this.context.SaveChanges();
            }
            

            return RedirectToAction("Login", "User");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Login(Login user)
        {
            var data = this.context.User.Where(x => x.Email == user.Email).FirstOrDefault();
            
            if(data == null || !BCrypt.Net.BCrypt.Verify(user.Password , data.Password))
            {
                TempData["Error"] = "Invalid Credentials";
                return View(user);
            }

            HttpContext.Session.SetString("User_Name", data.FullName);
            HttpContext.Session.SetInt32("User_ID", data.UserID);
            HttpContext.Session.SetString("User_Role", data.Role);

            if(data.Role == "Admin")
            {
                return RedirectToAction("Index", "Admin");
            }

            return RedirectToAction("Index" ,"Home");
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User_Name");
            HttpContext.Session.Remove("User_ID");
            HttpContext.Session.Remove("User_Role");

            return RedirectToAction("Index" ,"Home");
        }

        
    }
}
