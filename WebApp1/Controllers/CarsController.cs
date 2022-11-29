using api1Domain.Models;
using api1Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi1.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CarsController : Controller
    {
        private readonly ICarService carService;

        public CarsController(ICarService carService)
        {
            this.carService = carService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await carService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> GetByModel(string model)
        {
            return Ok(await carService.GetByModel(model));
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var car = await carService.GetById(id);
            return Ok(car);
        }

        [HttpGet]
        public async Task<IActionResult> GetByMake(string make)
        {
            var cars = await carService.GetbyMake(make);
            return Ok(cars);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Car car)
        {
            var res = await carService.Add(car);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Car car)
        {
            var res = await carService.Delete(car);
            return Ok(res);

        }

        [HttpPut]
        public async Task<IActionResult> Update(Car car)
        {
            var res = await carService.Update(car);
            return Ok(res);
        }
    }
}
