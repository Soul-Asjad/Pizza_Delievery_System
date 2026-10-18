using Microsoft.AspNetCore.Mvc;
using Pizza_Delievery_System.Models;

namespace Pizza_Delievery_System.Controllers
{
    public class PizzaDealsController : Controller
    {
        private readonly PizzaDBContext context;
        private readonly IWebHostEnvironment env;

        public PizzaDealsController(PizzaDBContext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }

        public IActionResult ADD_Deals()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ADD_Deals(Pizza_Deals data, IFormFile Image)
        {
            var existing_deal = this.context.Pizza_Deals.FirstOrDefault(d => d.DealName == data.DealName);

            if(existing_deal != null)
            {
                ModelState.AddModelError("DealName", "Deal Name already exists.");
                return View(data);
            }

            if (Image != null)
            {
                var fileName = Guid.NewGuid().ToString() + " - " +Image.FileName;
                var filePath = Path.Combine(env.WebRootPath, "All_Images/Deals/", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }
                data.Image = fileName;
                this.context.Pizza_Deals.Add(data);
                this.context.SaveChanges();
            }

            return RedirectToAction("ADD_Deals" , "PizzaDeals");

        }
    }
}
