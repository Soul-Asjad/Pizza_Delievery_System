using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza_Delievery_System.Models
{
    public class EmailVerificationToken
    {
        
        [Key]
        public int EmailVerificationTokenID { get; set; }
        
        public int UserID { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public DateTime ExpireAt { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("UserID")]
        public User Users { get; set; }
    }
}
