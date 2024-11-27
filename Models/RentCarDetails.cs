using System.ComponentModel.DataAnnotations;

namespace Car_Rental_Api.Models
{
    public class RentCarDetails
    {
        //This is only for RentCar datatype not include in Database
        [Required]
        public Guid id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
    }
}
