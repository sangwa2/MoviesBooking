namespace MoviesAppModels.Models {
    public class MovieEntity{  


        public int id { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public string director { get; set; }
        public string cast { get; set; }
        public string genre { get; set; }
        public string notes { get; set; }

        public MovieEntity() {
                    
        }
        public virtual RunningTimeEntity? RunningTimeEntities { get; set; }
        public Bookings? Bookings { get; set; } = null;
    }
}
