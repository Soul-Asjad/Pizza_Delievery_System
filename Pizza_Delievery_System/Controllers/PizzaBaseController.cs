using Microsoft.AspNetCore.Mvc;
using Pizza_Delievery_System.Models;

namespace Pizza_Delievery_System.Controllers
{
    public class PizzaBaseController : Controller
    {
        private readonly PizzaDBContext context;


        public PizzaBaseController(PizzaDBContext context)
        {
            this.context = context;
        }

        //________________________________________________________________________________________________


        [HttpGet]
        public IActionResult AddPizzaBase()
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }

        [HttpPost]
        public IActionResult AddPizzaBase(PizzaBase data)
        {
            var PizzaBase = this.context.PizzaBase.FirstOrDefault(x => x.Name == data.Name);

            if (PizzaBase != null)
            {
                TempData["Error"] = "Already exist this name of PizzaBase";
                return View(data);
            }

            this.context.PizzaBase.Add(data);
            this.context.SaveChanges();



            return RedirectToAction("AddPizzaBase", "PizzaBase");
        }


        //________________________________________________________________________________________________


        public IActionResult PizzaBaseList()
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            var list = this.context.PizzaBase.ToList();
            return View(list);
        }

        //________________________________________________________________________________________________

        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            var data = this.context.PizzaBase.FirstOrDefault(x => x.PizzaBaseID == id);

            this.context.PizzaBase.Remove(data);
            this.context.SaveChanges();

            return RedirectToAction("PizzaBaseList", "PizzaBase");
        }

        //________________________________________________________________________________________________

        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            var data = this.context.PizzaBase.FirstOrDefault(x => x.PizzaBaseID == id);
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

            var data = this.context.PizzaBase.FirstOrDefault(x => x.PizzaBaseID == id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(PizzaBase data)
        {
            var old_data = this.context.PizzaBase.FirstOrDefault(x => x.PizzaBaseID == data.PizzaBaseID);

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
            return RedirectToAction("PizzaBaseList", "PizzaBase");
        }

        //________________________________________________________________________________________________

    }
}
