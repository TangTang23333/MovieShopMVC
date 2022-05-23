using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// 
namespace Infrastructure.Data
{
    public class MovieShopDbContext : DbContext
    {
        // use base class constructors
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
        {



        }
        // specify dbset(tables), as a property of the dbcontext !!!!

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Trailer> Trailer { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }
        public DbSet<MovieCast> MovieCast { get; set; }
        public DbSet<MovieCrew> MovieCrew { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Cast> Cast { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        public DbSet<CartItem> CartItem { get; set; }




        // to use fluent api, have to override OnModelCreating 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // specify the rules for Entity
            modelBuilder.Entity<MovieCrew>(ConfigureMovieCrew);
            modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
            modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
            modelBuilder.Entity<Genre>(ConfigureGenre);
            modelBuilder.Entity<Review>(ConfigureReview);
            modelBuilder.Entity<UserRole>(ConfigureUserRole);



        }

        private void ConfigureGenre(EntityTypeBuilder<Genre> builder)
        {
            // specify the fluent API with rules for Genre table
            // fluent api takes precedence, run fluent api rather than other config.
            builder.ToTable("Genre");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Name).HasMaxLength(150).IsRequired();


        }

        //fluent api has more options 
        private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> builder)
        {
            // have MovieId and GenreId as Pk and table name to be MovieGenre
            builder.ToTable("MovieGenre");
            builder.HasKey(mg => new { mg.MovieId, mg.GenreId });
        }



        private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
        {
            // specify the fluent API with rules for Genre table
            // fluent api takes precedence, run fluent api rather than other config.

            builder.HasKey(mc => new { mc.MovieId, mc.CastId, mc.Character });

        }


        private void ConfigureMovieCrew(EntityTypeBuilder<MovieCrew> builder)
        {
            // specify the fluent API with rules for Genre table
            // fluent api takes precedence, run fluent api rather than other config.
            builder.HasKey(mc => new { mc.MovieId, mc.CrewId, mc.Job, mc.Department });

        }


        private void ConfigureUserRole(EntityTypeBuilder<UserRole> builder)
        {


            builder.HasKey(ur => new { ur.RoleId, ur.UserId });


        }




        private void ConfigureReview(EntityTypeBuilder<Review> builder)
        {

            builder.HasKey(r => new { r.MovieId, r.UserId });


        }




    }
}
