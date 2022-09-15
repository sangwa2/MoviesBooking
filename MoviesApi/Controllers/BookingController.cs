using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;
using MoviesApi.Models;
using MoviesAppModels.Models;

namespace MoviesApi.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase {

        private readonly DataContext bookingContext;

        private readonly BookingRepository bookingRepository;

        public BookingController(DataContext context) {
            bookingContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bookings>>>  Index() {
            return await bookingContext.Bookings
                .Include(e => e.movieEntity)
                .ToListAsync();

        }
        [HttpPost]
        public async Task<ActionResult<Bookings>> AddBooking([FromBody] Bookings bookings) {
            Console.WriteLine(" ----------------- Done saving in DB ...");
            return Ok(await bookingRepository.AddBooking(bookings));
            //return  CreatedAtAction("Index", new { id = bookings.id }, bookings);
        }


    }
}
