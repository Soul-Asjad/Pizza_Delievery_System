using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza_Delievery_System.Models
{
    public class Pizza_Deals
    {
        [Key]
        public int DealID { get; set; }

        public string DealName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public bool Isactive { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ICollection<DealPizza> DealPizzas { get; set; }
            = new List<DealPizza>();
    }

}
