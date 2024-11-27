using Car_Rental_Api.Models;
using Car_Rental_Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rental_Api.Services
{
    public class UserService:ControllerBase,IUserService
    {
        private readonly IUserRepo userrepo;
        public UserService(IUserRepo userrepo)
        {
            this.userrepo = userrepo;
        }

        //here we simply use repo for login and register
        public IActionResult RegisterUser(User user)
        {
            return userrepo.RegisterUser(user);
        }
        public ActionResult LoginUser(LoginCredentials credentials)
        {
            return userrepo.LoginUser(credentials);
        }
    }
}
