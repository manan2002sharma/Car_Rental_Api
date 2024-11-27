using Car_Rental_Api.Models;
using Car_Rental_Api.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Car_Rental_Api.Services
{
    public class CarService : ControllerBase,ICarService
    {
        private readonly ICarRepo carRepo;
        private readonly IEmailService emailService;
        public CarService(ICarRepo carRepo,IEmailService emailService)
        {
            this.carRepo = carRepo;
            this.emailService = emailService;
        }


        //Uses repo for adding car
        public IActionResult addCar(Car car)
        {
           return carRepo.AddCar(car);
        }

        //uses repo to update car availability
        public ActionResult<Car> UpdateCarAvailability(Guid id)
        {
            return carRepo.UpdateCarAvailabilty(id);
        }

        //Uses repo to get cars
        public ActionResult<IEnumerable<Car>> GetAvailableCars()
        {
            return carRepo.GetAvailableCars();
        }


        //here also same use repo 
        public ActionResult<Car> GetCarById(Guid id)
        {
            return carRepo.GetCarById(id);
        }


        //This uses getcarbyid and check if car is available than change availability and send mail 
        public ActionResult<Car> RentCar(RentCarDetails details)
        {
            //getting car with id
            var actionResult = carRepo.GetCarById(details.id);

            //checking if car is found
            if (actionResult.Result is NotFoundObjectResult) return NotFound();
            var currCar = (actionResult.Result as OkObjectResult)?.Value as Car;
            if (currCar == null) return NotFound();

            //checking if car is available
            if (!currCar.IsAvailable) return NotFound("Car is currently unavailable");
            //updating availability
            carRepo.UpdateCarAvailabilty(details.id);

            string carDetails = $"Your car's id is {currCar.Id} Car model is {currCar.Model} Price per day will be {currCar.PricePerDay}";
            
            //sending mail using mail service
            emailService.SendEmailAsync(details.Email,"Car Details", carDetails);
            return Ok(currCar);
        }
    }
}
