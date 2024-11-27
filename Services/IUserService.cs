using Car_Rental_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rental_Api.Services
{
    public interface IUserService
    {
        IActionResult RegisterUser(User user);
        ActionResult LoginUser(LoginCredentials credentials);
    }
}
