using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi2.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly ICarService carService;

        public CarsController(ICarService carService)
        {
            this.carService = carService;

        }

        [HttpGet("getcars")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await carService.GetAll());
        }

        [HttpGet("getbymodel/{model}")]
        public async Task<IActionResult> GetByModel(string model)
        {
            return Ok(await carService.GetByModel(model));
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var car = await carService.GetById(id);
            return Ok(car);
        }

        [HttpGet("getbymake/{make}")]
        public async Task<IActionResult> GetByMake(string make)
        {
            var cars = await carService.GetbyMake(make);
            return Ok(cars);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Car car)
        {
            var res = await carService.Add(car);
            return Ok(res);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(Car car)
        {
            var res = await carService.Delete(car);
            return Ok(res);

        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Car car)
        {
            var res = await carService.Update(car);
            return Ok(res);
        }
    }
}
