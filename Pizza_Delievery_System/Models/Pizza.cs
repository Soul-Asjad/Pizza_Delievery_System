using System.ComponentModel.DataAnnotations;

namespace Pizza_Delievery_System.Models
{
    public class Pizza
    {

        [Key]
        public int PizzaID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price {  get; set; }

        [Required]
        public string Image { get; set; }

        public string IsAvaiable { get; set; } = "Available";

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    
    }
}
