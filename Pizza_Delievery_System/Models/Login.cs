using System.ComponentModel.DataAnnotations;

namespace Pizza_Delievery_System.Models
{
    public class Login
    {

        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression(@"^[a-zA-Z]{8,16}$")]
        public string Password { get; set; }
    }
}
