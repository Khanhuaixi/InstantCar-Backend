using ServiceApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly BackendDBContext _context;

        public CarsController(BackendDBContext context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await _context.Cars.ToListAsync();
        }

        // GET: api/Cars/5
        [HttpGet("{car_id}")]
        public async Task<ActionResult<IEnumerable<Car>>> GetCarByCarId(string car_id)
        {
            IEnumerable<Car> cars;

            if (string.IsNullOrEmpty(car_id))
                cars = await _context.Cars.ToListAsync();
            else
                cars = await _context.Cars.Where(tr => tr.CarId == car_id).ToListAsync();

            return Ok(cars);
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{car_id}")]
        public async Task<IActionResult> PutCar(string car_id, Car car)
        {
            if (car_id != car.CarId)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(car_id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            if (!CarExists(car.CarId))
            {
                _context.Cars.Add(car);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCarByCarId", new { car_id = car.CarId }, car);
            }

            else
            {
                return BadRequest();
            }

        }

        // DELETE: api/Cars/5
        [HttpDelete("{car_id}")]
        public async Task<IActionResult> DeleteCar(string car_id)
        {
            var car = await _context.Cars.Where(tr => tr.CarId == car_id).ToListAsync();
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car.First());
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarExists(string car_id)
        {
            return _context.Cars.Any(e => e.CarId == car_id);
        }
    }
}