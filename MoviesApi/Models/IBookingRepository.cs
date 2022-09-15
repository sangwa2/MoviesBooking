using MoviesAppModels.Models;

namespace MoviesApi.Models {
    public interface IBookingRepository {
        Task<Bookings> AddBooking(Bookings bookings);
    }
}
