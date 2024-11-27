using Car_Rental_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rental_Api.Repositories
{
    public interface ICarRepo
    {
        IActionResult AddCar(Car car);
        ActionResult<Car> UpdateCarAvailabilty(Guid id);
        ActionResult<IEnumerable<Car>> GetAvailableCars();
        ActionResult<Car> GetCarById(Guid id);

    }
}
