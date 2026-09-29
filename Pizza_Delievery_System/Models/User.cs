using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Pizza_Delievery_System.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        public string? FullName { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public bool IsEmailVerified { get; set; }

        [RegularExpression(@"^[a-zA-Z]{8,16}$")]
        public string Password { get; set; }
        
        public string Role { get; set; } = "User" ;

        public string IsActive { get; set; } = "Active" ;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
