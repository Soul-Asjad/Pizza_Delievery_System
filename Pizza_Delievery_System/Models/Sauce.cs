using System.ComponentModel.DataAnnotations;

namespace Pizza_Delievery_System.Models
{
    public class Sauce
    {

        [Key]
        public int SauceID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        public int LowStockThreshold { get; set; }

        public string IsAvailable { get; set; } = "Available";

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
