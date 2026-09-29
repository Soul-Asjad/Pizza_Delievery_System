using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza_Delievery_System.Models
{
    public class OrderItem
    {

        [Key]
        public int OrderItemID { get; set; }
    
        public int OrderID { get; set; }

        public int PizzaID { get; set; }

        public int CustomPizzaID { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [ForeignKey("OrderID")]
        public Order Orders { get; set; }

        [ForeignKey("PizzaID")]
        public Pizza Pizza { get; set; }

        [ForeignKey("CustomPizzaID")]
        public CustomPizza CustomPizza { get; set; }
    }
}
