using Microsoft.AspNetCore.Mvc;
using Pizza_Delievery_System.Models;

namespace Pizza_Delievery_System.Controllers
{
    public class VegetableController : Controller
    {
        private readonly PizzaDBContext context;
        

        public VegetableController(PizzaDBContext context)
        {
            this.context = context;
        }

        //________________________________________________________________________________________________


        [HttpGet]
        public IActionResult AddVegetable()
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }

        [HttpPost]
        public IActionResult AddVegetable(Vegetable data)
        {
            var Vegetable = this.context.Vegetable.FirstOrDefault(x => x.Name == data.Name);

            if (Vegetable != null)
            {
                TempData["Error"] = "Already exist this name of Vegetable";
                return View(data);
            }

            this.context.Vegetable.Add(data);
            this.context.SaveChanges();



            return RedirectToAction("AddVegetable", "Vegetable");
        }


        //________________________________________________________________________________________________


        public IActionResult VegetableList()
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            var list = this.context.Vegetable.ToList();
            return View(list);
        }

        //________________________________________________________________________________________________

        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            var data = this.context.Vegetable.FirstOrDefault(x => x.VegetableID == id);

            this.context.Vegetable.Remove(data);
            this.context.SaveChanges();

            return RedirectToAction("VegetableList", "Vegetable");
        }

        //________________________________________________________________________________________________

        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            var data = this.context.Vegetable.FirstOrDefault(x => x.VegetableID == id);
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

            var data = this.context.Vegetable.FirstOrDefault(x => x.VegetableID == id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Vegetable data)
        {
            var old_data = this.context.Vegetable.FirstOrDefault(x => x.VegetableID == data.VegetableID);

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
            return RedirectToAction("VegetableList", "Vegetable");
        }

        //________________________________________________________________________________________________

    }
}
