using Car_Rental_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rental_Api.Services
{
    public interface ICarService
    {
        IActionResult addCar(Car car);
        ActionResult<Car> GetCarById(Guid id);
        ActionResult<IEnumerable<Car>> GetAvailableCars();
        ActionResult<Car> UpdateCarAvailability(Guid id);
        ActionResult<Car> RentCar(RentCarDetails details);
    }
}
