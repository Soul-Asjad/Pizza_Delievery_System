using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza_Delievery_System.Models
{
    public class Address
    {

        [Key]
        public int AddressID { get; set; }

        public int UserID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        
        [Required]
        public string AddressLine {  get; set; }

        [Required]
        public string City { get; set; }

        public string? Area { get; set; }
        
        public string? PostalCode { get; set; }

        public string? AdditionalInstruction { get; set; }

        public string IsDefault = "Yes";

        public DateTime OrderDate = DateTime.UtcNow;

        [ForeignKey("UserID")]
        public User Users { get; set; }
    
    }
}
