using System.ComponentModel.DataAnnotations;

namespace Car_Rental_Api.Models
{
    public class LoginCredentials
    {
        //This is for only login not included in Dbcontext therefore not in Database
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }
    }
}
