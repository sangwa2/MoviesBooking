

using Microsoft.EntityFrameworkCore;
using MoviesAppModels.Models;

namespace MoviesApi.Data {

    public partial class DataContext : DbContext {

        public DataContext(DbContextOptions options) : base(options) {

        }

        public DbSet<MovieEntity> MovieEntity { get; set; }
        public DbSet<RunningTimeEntity> RunningTimeEntity { get; set; }
        public DbSet<Bookings> Bookings { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<MovieEntity>(entity => {
                entity.ToTable("MovieEntity");
                entity.Property(e => e.id).ValueGeneratedOnAdd();
                entity.Property(e => e.title).HasColumnType("VARCHAR(8000)");
                entity.Property(e => e.year).HasColumnType("VARCHAR(8000)");
                entity.Property(e => e.director).HasColumnType("VARCHAR(8000)");
                entity.Property(e => e.cast).HasColumnType("VARCHAR(8000)");
                entity.Property(e => e.genre).HasColumnType("VARCHAR(8000)");
                entity.Property(e => e.notes).HasColumnType("VARCHAR(8000)");
                entity
                   .HasOne(r => r.RunningTimeEntities)
                   .WithOne(e => e.movieEntity).IsRequired(false)
                   ;
                    

            });
            modelBuilder.Entity<RunningTimeEntity>(entity => {
            entity.ToTable("RunningTimeEntity");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.mon).HasColumnType("VARCHAR(8000)");
            entity.Property(e => e.tue).HasColumnType("VARCHAR(8000)");
            entity.Property(e => e.wed).HasColumnType("VARCHAR(8000)");
            entity.Property(e => e.thu).HasColumnType("VARCHAR(8000)");
            entity.Property(e => e.fri).HasColumnType("VARCHAR(8000)");
            entity.Property(e => e.sat).HasColumnType("VARCHAR(8000)");
            entity.Property(e => e.sun).HasColumnType("VARCHAR(8000)");

            

            });

            modelBuilder.Entity<Bookings>(entity => {
                entity.ToTable("Bookings");
                entity.Property(b => b.id).ValueGeneratedOnAdd();
                entity.Property(b => b.day).HasColumnType("VARCHAR(8000)");
                entity.Property(b => b.hour).HasColumnType("VARCHAR(8000)");
                entity.Property(b => b.MovieId).HasColumnType("VARCHAR(8000)");

                entity
                  .HasOne(m => m.movieEntity)
                  .WithOne(b => b.Bookings)
                  .HasForeignKey<Bookings>(d => d.MovieId);

            });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
