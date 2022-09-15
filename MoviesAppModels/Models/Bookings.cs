using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesAppModels.Models {
    public class Bookings {
        private readonly int movie;

        public int id { get; set; }

        public string day { get; set; }

        public string hour { get; set; }
        [ForeignKey("movieentityid")]
        public int MovieId { get; set; }

        public Bookings() {

        }

        public Bookings(string day, string hour, int movie) {
            this.day = day;
            this.hour = hour;
            this.movie = movie;
        }
        public MovieEntity? movieEntity { get; set; } = null;
    }
}
