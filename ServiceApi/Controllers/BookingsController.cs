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
    public class BookingsController : ControllerBase
    {
        private readonly BackendDBContext _context;

        public BookingsController(BackendDBContext context)
        {
            _context = context;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            return await _context.Bookings.ToListAsync();
        }


        // GET: api/Bookings/5
        [HttpGet("{booking_id}")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookingByBookingId(string booking_id)
        {

            if (string.IsNullOrEmpty(booking_id))
                return await _context.Bookings.ToListAsync();
            else
                return await _context.Bookings.Where(tr => tr.BookingId == booking_id).ToListAsync();

        }

        // GET: api/Bookings/user_id?user_id={user_id}
        [HttpGet("user_id")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookingByUserId([FromQuery(Name = "user_id")] string user_id)
        {

            return await _context.Bookings.Where(tr => tr.UserId == user_id).ToListAsync();

        }

        // PUT: api/Bookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{booking_id}")]
        public async Task<IActionResult> PutBooking(string booking_id, Booking booking)
        {
            if (booking_id != booking.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(booking.BookingId))
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

        // POST: api/Bookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            if (!BookingExists(booking.BookingId))
            {
                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetBookingByBookingId", new { booking_id = booking.Id }, booking);
            }
            else
            {
                return BadRequest();
            }

        }

        // DELETE: api/Bookings/5
        [HttpDelete("{booking_id}")]
        public async Task<IActionResult> DeleteBooking(string booking_id)
        {
            var booking = await _context.Bookings.Where(tr => tr.BookingId == booking_id).ToListAsync();
            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking.First());
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingExists(string booking_id)
        {
            return _context.Bookings.Any(e => e.BookingId == booking_id);
        }
    }
}