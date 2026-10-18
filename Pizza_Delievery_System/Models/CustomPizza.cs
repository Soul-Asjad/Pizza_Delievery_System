using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza_Delievery_System.Models
{
    public class CustomPizza
    {
        [Key]
        public int CustomPizzaID { get; set; }

        public int UserID { get; set; }

        [Required]
        public string Size { get; set; }
        [Required]
        public int PizzaBaseID { get; set; }
        [Required]
        public int SauceID { get; set; }
        [Required]
        public int CheeseID { get; set; }
        [Required]
        public int ToppingID { get; set; }
        public decimal TotalPrice { get; set; }

        public DateTime CreatedDate { get; set; }


        // Relationships

        [ForeignKey("UserID")]
        public User User { get; set; }

        [ForeignKey("PizzaBaseID")]
        public PizzaBase PizzaBase { get; set; }

        [ForeignKey("SauceID")]
        public Sauce Sauce { get; set; }

        [ForeignKey("CheeseID")]
        public Cheese Cheese { get; set; }

        [ForeignKey("ToppingID")]
        public Toppings Toppings { get; set; }

    }
}
