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
    public class CarModelsController : ControllerBase
    {
        private readonly BackendDBContext _context;

        public CarModelsController(BackendDBContext context)
        {
            _context = context;
        }

        // GET: api/CarModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarModel>>> GetCarModels()
        {
            return await _context.CarModels.ToListAsync();
        }

        // GET: api/CarModels/5
        [HttpGet("{car_model_id}")]
        public async Task<ActionResult<IEnumerable<CarModel>>> GetCarModelByCarModelId(string car_model_id)
        {

            if (string.IsNullOrEmpty(car_model_id))
                 return await _context.CarModels.ToListAsync();
            else
                return await _context.CarModels.Where(tr => tr.CarModelId == car_model_id).ToListAsync();

        }

        // PUT: api/CarModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{car_model_id}")]
        public async Task<IActionResult> PutCarModel(string car_model_id, CarModel carModel)
        {
            if (car_model_id != carModel.CarModelId)
            {
                return BadRequest();
            }

            _context.Entry(carModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarModelExists(car_model_id))
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

        // POST: api/CarModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarModel>> PostCarModel(CarModel carModel)
        {
            if (!CarModelExists(carModel.CarModelId))
            {
                _context.CarModels.Add(carModel);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCarModelByCarModelId", new { car_model_id = carModel.CarModelId }, carModel);
            }
            else
            {
                return BadRequest();
            }

        }

        // DELETE: api/CarModels/5
        [HttpDelete("{car_model_id}")]
        public async Task<IActionResult> DeleteCarModel(string car_model_id)
        {
            var carModel = await _context.CarModels.Where(tr => tr.CarModelId == car_model_id).ToListAsync();
            if (carModel == null)
            {
                return NotFound();
            }

            _context.CarModels.Remove(carModel.First());
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarModelExists(string car_model_id)
        {
            return _context.CarModels.Any(e => e.CarModelId == car_model_id);
        }
    }
}