using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesAppModels.Models {
    public class RunningTimeEntity {
        public int Id { get; set; }
        public string mon { get; set; }
        public string tue { get; set; }
        public string wed { get; set; }
        public string thu { get; set; }
        public string fri { get; set; }
        public string sat { get; set; }
        public string sun { get; set; }
        public RunningTimeEntity() {

        }
        public RunningTimeEntity(int id, string mon, string tue, string wed, string thu, string fri, string sat, string sun) {
            Id = id;
            this.mon = mon;
            this.tue = tue;
            this.wed = wed;
            this.thu = thu;
            this.fri = fri;
            this.sat = sat;
            this.sun = sun;
        }
        public RunningTimeEntity(string mon, string tue, string wed, string thu, string fri, string sat, string sun) {
            this.mon = mon;
            this.tue = tue;
            this.wed = wed;
            this.thu = thu;
            this.fri = fri;
            this.sat = sat;
            this.sun = sun;
        }
        [ForeignKey("movieentityid")]
        public int movieentityid { get; set; }

        public MovieEntity? movieEntity;

    }
}
