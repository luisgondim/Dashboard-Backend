using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.Interfaces;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cars : ControllerBase
    {
        private readonly ICarsService _carsServices;

        public Cars(ICarsService carsServices)
        {
            _carsServices = carsServices;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            var cars = await _carsServices.GetCars();
            return Ok (cars);
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _carsServices.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok (car);    
        }

        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.CarID)
            {
                return BadRequest();
            }

            try
            {
                await _carsServices.UpdateCar(id, car);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }


        // POST: api/Cars
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            await _carsServices.AddCar(car);

            return CreatedAtAction(nameof(GetCar), new { id = car.CarID }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var result = await _carsServices.DeleteCar(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
