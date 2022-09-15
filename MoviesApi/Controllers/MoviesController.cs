using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;
using MoviesAppModels;
using MoviesAppModels.Models;
using System.Net;
using System.Text;

namespace MoviesApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase {


        private readonly DataContext _ctx;

        public MoviesController(DataContext ctx) {
            _ctx = ctx;
        }

        //GET: api/Movies/remote
        [HttpGet("remote")]
        public async Task<IActionResult> IndexAsync() {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string url = "https://college-movies.herokuapp.com/";
            string json = new WebClient().DownloadString(url);
            var movieList = System.Text.Json.JsonSerializer.Deserialize<List<Movie>>(json);
            using var movieJsonStream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            //Download API data and save in the database
            await foreach (var item in System.Text.Json.JsonSerializer.DeserializeAsyncEnumerable<Movie>(movieJsonStream)) {
                Console.WriteLine("========= movie: " + item.id + " - " + item.title + " - " + item.year);


                String monStr = null;
                String tueStr = null;
                String wedStr = null;
                String thuStr = null;
                String friStr = null;
                String satStr = null;
                String sunStr = null;


                Runningtimes rt = new Runningtimes {
                    mon = item.runningTimes.mon,
                    tue = item.runningTimes.tue,
                    wed = item.runningTimes.wed,
                    thu = item.runningTimes.thu,
                    fri = item.runningTimes.fri,
                    sat = item.runningTimes.sat,
                    sun = item.runningTimes.sat
                };


                string[] result = null;

                ParseArray pa = new ParseArray();
                monStr = pa.parse(result, rt.mon);
                tueStr = pa.parse(result, rt.tue);
                wedStr = pa.parse(result, rt.wed);
                thuStr = pa.parse(result, rt.thu);
                friStr = pa.parse(result, rt.fri);
                satStr = pa.parse(result, rt.sat);
                sunStr = pa.parse(result, rt.sun);

                RunningTimeEntity runningTimeEntity = new RunningTimeEntity(monStr, tueStr, wedStr, thuStr, friStr, satStr, sunStr);
                MovieEntity movieEntity = new MovieEntity { id = item.id, title = item.title, year = item.year, director = item.director, cast = item.cast, genre = item.genre, notes = item.notes };


                int currentMovieId = movieEntity.id;
                runningTimeEntity.movieentityid = currentMovieId;


                try {
                    _ctx.MovieEntity.Add(movieEntity);
                    _ctx.RunningTimeEntity.Add(runningTimeEntity);
                    _ctx.SaveChanges();

                } catch (Exception ex) {
                    Console.WriteLine("An Error has occured, check if Unique keys are violated");
                    Console.WriteLine(ex.ToString());
                }

            }

            return Content(json);

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieEntity>>> GetLocalMovies() {

            return await _ctx.MovieEntity
                .Include(e => e.RunningTimeEntities)
                .ToListAsync();
        }


    }
}
