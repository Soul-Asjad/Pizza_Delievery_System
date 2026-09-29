using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza_Delievery_System.Models
{
    public class CustomPizzaVegetable
    {

        [Key]
        public int CustomPizzaVegetableId { get; set; }

        public int CustomPizzaID { get; set; }

        public int VegetableID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey("CustomPizzaID")]
        public CustomPizza CustomPizza { get; set; }

        [ForeignKey("VegetableID")]
        public Vegetable Vegetable { get; set; }



    }
}
