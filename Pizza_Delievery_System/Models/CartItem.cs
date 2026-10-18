using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza_Delievery_System.Models
{
    public class CartItem
    {

        [Key]
        public int CartItemID { get; set; }

        public int CartID { get; set; }

        public int? PizzaID { get; set; }

        public int? CustomPizzaID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public DateTime AddedDate { get; set; } = DateTime.UtcNow;

        [ForeignKey("CartID")]
        public Cart Cart { get; set; }

        [ForeignKey("PizzaID")]
        public Pizza Pizza { get; set; }

        [ForeignKey("CustomPizzaID")]
        public CustomPizza CustomPizza { get; set; }
    }
}
