using Microsoft.AspNetCore.Mvc;
using Pizza_Delievery_System.Models;

namespace Pizza_Delievery_System.Controllers
{
    public class ToppingController : Controller
    {
        private readonly PizzaDBContext context;


        public ToppingController(PizzaDBContext context)
        {
            this.context = context;
        }

        //________________________________________________________________________________________________


        [HttpGet]
        public IActionResult AddTopping()
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }

        [HttpPost]
        public IActionResult AddTopping(Toppings data)
        {

            var Cheese = this.context.Toppings.FirstOrDefault(x => x.Name == data.Name);

            if (Cheese != null)
            {
                TempData["Error"] = "Already exist this name of Topping";
                return View(data);
            }

            this.context.Toppings.Add(data);
            this.context.SaveChanges();



            return RedirectToAction("AddTopping", "Topping");
        }


        //________________________________________________________________________________________________


        public IActionResult ToppingList()
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            var list = this.context.Toppings.ToList();
            return View(list);
        }

        //________________________________________________________________________________________________

        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            var data = this.context.Toppings.FirstOrDefault(x => x.ToppingID == id);

            this.context.Toppings.Remove(data);
            this.context.SaveChanges();

            return RedirectToAction("ToppingList", "Topping");
        }

        //________________________________________________________________________________________________

        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            var data = this.context.Toppings.FirstOrDefault(x => x.ToppingID == id);
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

            var data = this.context.Toppings.FirstOrDefault(x => x.ToppingID == id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Toppings data)
        {
            var old_data = this.context.Toppings.FirstOrDefault(x => x.ToppingID == data.ToppingID);

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
            return RedirectToAction("ToppingList", "Topping");
        }

        //________________________________________________________________________________________________

    }
}
