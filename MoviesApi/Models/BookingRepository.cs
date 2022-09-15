using MoviesApi.Data;
using MoviesAppModels.Models;

namespace MoviesApi.Models {
    public class BookingRepository : IBookingRepository {
        private readonly DataContext dataContext;

        public BookingRepository(DataContext appDbContext) {
            dataContext = appDbContext;
        }

        public async Task<Bookings> AddBooking(Bookings bookings) {
            var result = await dataContext.Bookings.AddAsync(bookings);
            await dataContext.SaveChangesAsync();
            return result.Entity;
        }
 
    }

}
