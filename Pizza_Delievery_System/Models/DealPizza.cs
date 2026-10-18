using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza_Delievery_System.Models
{
    public class DealPizza
    {
        [Key]
        public int DealPizzaID { get; set; }

        public int DealID { get; set; }

        public int PizzaID { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("PizzaID")]
        public Pizza Pizza { get; set; }

        [ForeignKey("DealID")]
        public Pizza_Deals Deal { get; set; }
    }

}
