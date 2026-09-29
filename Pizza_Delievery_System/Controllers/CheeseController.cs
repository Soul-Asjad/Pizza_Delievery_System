using Microsoft.AspNetCore.Mvc;
using Pizza_Delievery_System.Models;

namespace Pizza_Delievery_System.Controllers
{
    public class CheeseController : Controller
    {
        private readonly PizzaDBContext context;


        public CheeseController(PizzaDBContext context)
        {
            this.context = context;
        }

        //________________________________________________________________________________________________


        [HttpGet]
        public IActionResult AddCheese()
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }

        [HttpPost]
        public IActionResult AddCheese(Cheese data)
        {

            var Cheese = this.context.Cheese.FirstOrDefault(x => x.Name == data.Name);

            if (Cheese != null)
            {
                TempData["Error"] = "Already exist this name of Cheese";
                return View(data);
            }

            this.context.Cheese.Add(data);
            this.context.SaveChanges();



            return RedirectToAction("AddCheese", "Cheese");
        }


        //________________________________________________________________________________________________


        public IActionResult CheeseList()
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            var list = this.context.Cheese.ToList();
            return View(list);
        }

        //________________________________________________________________________________________________

        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            var data = this.context.Cheese.FirstOrDefault(x => x.CheeseID == id);

            this.context.Cheese.Remove(data);
            this.context.SaveChanges();

            return RedirectToAction("CheeseList", "Cheese");
        }

        //________________________________________________________________________________________________

        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            var data = this.context.Cheese.FirstOrDefault(x => x.CheeseID == id);
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

            var data = this.context.Cheese.FirstOrDefault(x => x.CheeseID == id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Cheese data)
        {
            var old_data = this.context.Cheese.FirstOrDefault(x => x.CheeseID == data.CheeseID);

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
            return RedirectToAction("CheeseList", "Cheese");
        }

        //________________________________________________________________________________________________

    }
}
