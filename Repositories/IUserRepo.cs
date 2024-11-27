using Car_Rental_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rental_Api.Repositories
{
    public interface IUserRepo
    {
        IActionResult RegisterUser(User user);
        ActionResult LoginUser(LoginCredentials credentials);
    }
}
