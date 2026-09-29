using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza_Delievery_System.Models
{
    public class Payment
    {

        [Key]
        public int PaymentID { get; set; }

        public int OrderID { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        [Required]
        public string PaymentStatus { get; set; }

        public string TransactionID { get; set; }

        public string GatewayOrderID { get; set; }

        public string GatewayPaymentId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public DateTime PaidDate { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [ForeignKey("OrderID")]
        public Order Orders { get; set; }

    }
}
