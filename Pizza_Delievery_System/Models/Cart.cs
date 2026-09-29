using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza_Delievery_System.Models
{
    public class Cart
    {

        [Key]
        public int CartID { get; set; }
        
        public int UserID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

        [ForeignKey("UserID")]
        public User Users { get; set; }
    
    }
}
