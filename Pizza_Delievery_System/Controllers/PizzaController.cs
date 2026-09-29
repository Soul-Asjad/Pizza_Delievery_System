using Microsoft.AspNetCore.Mvc;
using Pizza_Delievery_System.Models;

namespace Pizza_Delievery_System.Controllers
{
    public class PizzaController : Controller
    {
        private readonly PizzaDBContext context;
        private readonly IWebHostEnvironment env;

        public PizzaController(PizzaDBContext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }


        //________________________________________________________________________________________________


        [HttpGet]
        public IActionResult AddPizza()
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }

        [HttpPost]
        public IActionResult AddPizza(Pizza data, IFormFile Image)
        {
            var pizza = this.context.Pizza.FirstOrDefault(x => x.Name == data.Name);

            if(pizza != null)
            {
                TempData["Error"] = "Already exist this name of pizza";
                return View(data);
            }

            if(Image != null)
            {
                var filename = Guid.NewGuid().ToString() + " - " + Image.FileName;
                var path = Path.Combine(env.WebRootPath, "All_Images/Pizza/", filename);

                using(var stream = new FileStream(path, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }

                data.Image = filename;
                this.context.Pizza.Add(data);
                this.context.SaveChanges();
            }


            return RedirectToAction("AddPizza" , "Pizza");
        }


        //________________________________________________________________________________________________


        public IActionResult PizzaList()
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            var list = this.context.Pizza.ToList();
            return View(list);
        }

        //________________________________________________________________________________________________

        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            var data = this.context.Pizza.FirstOrDefault(x => x.PizzaID == id);

            this.context.Pizza.Remove(data);
            this.context.SaveChanges();

            return RedirectToAction("PizzaList", "Pizza");
        }

        //________________________________________________________________________________________________

        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("User_Role") != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            var data = this.context.Pizza.FirstOrDefault(x => x.PizzaID == id);
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

            var data = this.context.Pizza.FirstOrDefault(x => x.PizzaID == id);
            if(data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Pizza data , IFormFile Image)
        {
            var old_data = this.context.Pizza.FirstOrDefault(x => x.PizzaID == data.PizzaID);

            if(old_data == null)
            {
                return NotFound();
            }

            old_data.Price = data.Price;
            old_data.Description = data.Description;
            old_data.Name = data.Name;
            old_data.IsAvaiable = data.IsAvaiable;
            old_data.CreatedDate = DateTime.UtcNow;

            if (Image != null)
            {
                var filename = Guid.NewGuid().ToString() + " - " + Image.FileName;
                var path = Path.Combine(env.WebRootPath, "All_Images/Pizza/", filename);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }

                old_data.Image = filename;
            }

            this.context.SaveChanges();
            return RedirectToAction("PizzaList", "Pizza");
        }

        //________________________________________________________________________________________________



    }
}
