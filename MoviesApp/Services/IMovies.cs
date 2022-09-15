using MoviesAppModels;
using MoviesAppModels.Models;

namespace MoviesApp.Services {
    public interface IMovies {
        Task<List<Movie>> GerMovies();
        Task<List<MovieEntity>> GetLocalMovies();

        
    }
}
