using MoviesAppModels.Models;
using System.Net.Http.Json;

namespace MoviesApp.Services {
    public class BookingService : IBookings {
       private  readonly HttpClient httpClient;


         private HttpClient _httpService;

        public BookingService(HttpClient httpClient) {
            this.httpClient = httpClient;
        }

     

        public async Task<List<Bookings>> GetBookings() {
            return await httpClient.GetFromJsonAsync<List<Bookings>>("api/Bookings");
        }

     
    }
}
