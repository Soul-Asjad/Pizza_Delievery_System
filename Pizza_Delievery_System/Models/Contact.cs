using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza_Delievery_System.Models
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        
        public int UserID { get; set; }

        public string? FullName { get; set; }

        public string? PhoneNumber { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        [ForeignKey("UserID")]
        public User Users { get; set; }

    }
}
