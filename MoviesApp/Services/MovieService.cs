using MoviesAppModels;
using MoviesAppModels.Models;
using System.Net.Http.Json;

namespace MoviesApp.Services {
    public class MovieService : IMovies {
        public HttpClient httpClient;

        public MovieService(HttpClient httpClient) {
            this.httpClient = httpClient;
        }
 

        public async Task<List<Movie>> GerMovies() {
            return await httpClient.GetFromJsonAsync<List<Movie>>("api/Movies/remote");
        }
         

        public async Task<List<MovieEntity>> GetLocalMovies() {
            return await httpClient.GetFromJsonAsync<List<MovieEntity>>("api/Movies");
        }


       
    }
}
