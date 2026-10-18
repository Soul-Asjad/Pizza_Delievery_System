using Microsoft.AspNetCore.Mvc;
using Pizza_Delievery_System.Models;
using System.Runtime.CompilerServices;

namespace Pizza_Delievery_System.Controllers
{
    public class CartController : Controller
    {
        private readonly PizzaDBContext context;

        public CartController(PizzaDBContext context)
        {
            this.context = context;
        }

        public IActionResult AddtoCart(int id , int quantity)
        {
            var session = HttpContext.Session.GetInt32("User_ID");

            if (session == null)
            {
                return RedirectToAction("Login", "User");
            }

            var existing_cart = this.context.Cart.FirstOrDefault(x => x.UserID == session);

            if (existing_cart == null)
            {
                existing_cart = new Cart
                {
                    UserID = session.Value
                };
                this.context.Cart.Add(existing_cart);
                this.context.SaveChanges();
            }

            var existing_product = this.context.CartItems.FirstOrDefault(x => x.CartID == existing_cart.CartID && (x.PizzaID == id || x.CustomPizzaID == id));
            var custom_pizza = this.context.CustomPizza.FirstOrDefault(x => x.CustomPizzaID == id);
            var pizza = custom_pizza == null ? this.context.Pizza.FirstOrDefault(x => x.PizzaID == id) : null;

            if (quantity < 1)
            {
                quantity = 1;
            }

            if(existing_product != null)
            {
                existing_product.Quantity += quantity;
            }

            if(existing_product == null)
            {
                existing_product = new CartItem
                {
                    CartID = existing_cart.CartID,
                    Quantity = quantity
                };
                if(pizza != null)
                {
                    existing_product.PizzaID = pizza.PizzaID;
                    existing_product.UnitPrice = pizza.Price;
                    existing_product.TotalPrice = pizza.Price * quantity;
                }
                else
                {
                    existing_product.CustomPizzaID = custom_pizza.CustomPizzaID;
                    existing_product.UnitPrice = custom_pizza.TotalPrice;
                    existing_product.TotalPrice = custom_pizza.TotalPrice * quantity;
                }
                this.context.CartItems.Add(existing_product);
            }

            this.context.SaveChanges();
            return RedirectToAction("Index", "Home");

        }


    }
}
