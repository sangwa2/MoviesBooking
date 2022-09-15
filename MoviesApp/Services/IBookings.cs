

using MoviesAppModels.Models;

namespace MoviesApp.Services {
    public interface IBookings {
        Task<List<Bookings>> GetBookings();

        
    }
}
