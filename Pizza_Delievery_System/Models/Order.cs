using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza_Delievery_System.Models
{
    public class Order
    {

        public int OrderID { get; set; }

        public int UserID { get; set; }

        public int AddressID { get; set; }

        public string OrderNumber { get; set; } = "ORD-" + Guid.NewGuid().ToString("N")[..8].ToUpper();

        [Required]
        public decimal SubTotal { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public string OrderStatus { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [ForeignKey("UserID")]
        public User User { get; set; }

        [ForeignKey("AddressID")]
        public Address Address { get; set; }



    }
}
