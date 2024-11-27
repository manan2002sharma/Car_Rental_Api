using Car_Rental_Api.Data;
using Car_Rental_Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Api.Repositories
{
    public class CarRepo : ControllerBase,ICarRepo
    {
        private readonly AppDbContext context;
        public CarRepo(AppDbContext context)
        {
            this.context = context;
        }

        //simply adds car data to database
        public IActionResult AddCar(Car car)
        {
            context.Cars.Add(car);
            context.SaveChanges();
            return Ok();
        }

        //Finds car than toggle availability of car using id
        public ActionResult<Car> UpdateCarAvailabilty(Guid id)
        {
            var car = context.Cars.Find(id);
            if (car == null)
            {
                return NotFound($"Car with ID {id} was not found.");
            }
            car.IsAvailable = !car.IsAvailable;
            context.SaveChanges();

            return Ok(car);
        }

        //For finding car by id
        public ActionResult<Car> GetCarById(Guid id)
        {

            //Console.WriteLine("here repo");
            var result = context.Cars.Find(id);
            //Console.WriteLine($"Car {result.Id}");
            if (result == null) return NotFound($"Car with ID {id} was not found.");
            return Ok(result);
        }

        //getting all cars that has isavailable marked as true
        public ActionResult<IEnumerable<Car>> GetAvailableCars()
        {
            var result = context.Cars.Where(x=>x.IsAvailable==true);
            if (result == null) return NotFound();
            return Ok(result);
        }

    }
}
