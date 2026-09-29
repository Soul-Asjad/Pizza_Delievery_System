using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza_Delievery_System.Models
{
    public class CustomPizza
    {

        [Key]
        public int CustomPizzaID { get; set; }
    
        public int UserID { get; set; }

        public int PizzaBaseID { get; set; }

        public int SauceID { get; set; }

        public int CheeseID { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("UserID")]
        public User Users { get; set; }

        [ForeignKey("PizzaBaseID")]
        public PizzaBase PizzaBase { get; set; }

        [ForeignKey("SauceID")]
        public Sauce Sauce { get; set; }

        [ForeignKey("CheeseID")]
        public Cheese Cheese { get; set; }

    }
}
