using Car_Rental_Api.Data;
using Car_Rental_Api.Models;
using Car_Rental_Api.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Api.Repositories
{
    public class UserRepo : ControllerBase,IUserRepo
    {
        private readonly AppDbContext context;
        private readonly JwtService jwtsvc;
        public UserRepo(AppDbContext context , JwtService jwtsvc)
        {
            this.context = context;
            this.jwtsvc = jwtsvc;
        }


        //Simply loging in user 
        public IActionResult RegisterUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return Ok();
        }


        //Login user and then Based on role with that registered generate token 
        public ActionResult LoginUser(LoginCredentials
            loginCredentials)
        {
            User user =  context.Users.FirstOrDefault(u => u.Email == loginCredentials.Email && u.Password == loginCredentials.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            if (user.Role == "Admin")
            {
                var token = jwtsvc.GenerateToken(user.Name, "Admin");
                return  Ok(token);
            }
            if (user.Role == "User")
            {
                var token = jwtsvc.GenerateToken(user.Name, "User");
                return Ok(token);
            }
            return Unauthorized();
        }
    }
}
