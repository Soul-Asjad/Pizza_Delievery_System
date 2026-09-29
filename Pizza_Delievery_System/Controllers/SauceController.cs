using Microsoft.AspNetCore.Mvc;
using Pizza_Delievery_System.Models;

namespace Pizza_Delievery_System.Controllers
{
    public class SauceController : Controller
    {
        private readonly PizzaDBContext context;
        private readonly IWebHostEnvironment env;

        public SauceController(PizzaDBContext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }

        //________________________________________________________________________________________________


        [HttpGet]
        public IActionResult AddSauce()
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }

        [HttpPost]
        public IActionResult AddSauce(Sauce data, IFormFile Image)
        {
            var Sauce = this.context.Sauce.FirstOrDefault(x => x.Name == data.Name);

            if (Sauce != null)
            {
                TempData["Error"] = "Already exist this name of Sauce";
                return View(data);
            }
           
            this.context.Sauce.Add(data);
            this.context.SaveChanges();



            return RedirectToAction("AddSauce", "Sauce");
        }


        //________________________________________________________________________________________________


        public IActionResult SauceList()
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            var list = this.context.Sauce.ToList();
            return View(list);
        }

        //________________________________________________________________________________________________

        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            var data = this.context.Sauce.FirstOrDefault(x => x.SauceID == id);

            this.context.Sauce.Remove(data);
            this.context.SaveChanges();

            return RedirectToAction("SauceList", "Sauce");
        }

        //________________________________________________________________________________________________

        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            var data = this.context.Sauce.FirstOrDefault(x => x.SauceID == id);
            return View(data);
        }

        //________________________________________________________________________________________________

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            var data = this.context.Sauce.FirstOrDefault(x => x.SauceID == id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Sauce data, IFormFile Image)
        {
            var old_data = this.context.Sauce.FirstOrDefault(x => x.SauceID == data.SauceID);

            if (old_data == null)
            {
                return NotFound();
            }

            old_data.Name = data.Name;
            old_data.StockQuantity = data.StockQuantity;
            old_data.LowStockThreshold = data.LowStockThreshold;
            old_data.Price = data.Price;
            old_data.Description = data.Description;
            old_data.IsAvailable = data.IsAvailable;
            old_data.CreatedDate = DateTime.UtcNow;

            this.context.SaveChanges();
            return RedirectToAction("SauceList", "Sauce");
        }

        //________________________________________________________________________________________________



    }
}
