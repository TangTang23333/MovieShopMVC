using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class MovieRepository : IMovieRepository

    {
        // dapper (ORM)  -> stackoverflow 
        // ado.net , MICROSOFT sql connection ,sqlcommand, 
        // ENTITY FRAMEWORK ==> LINQ 

        private readonly MovieShopDbContext _context;
        public MovieRepository(MovieShopDbContext context)
        {
            this._context = context;
        }


        public List<Movie> GetTop30GlossingMovies()
        {
            // SQL Database 
            // data access logic
            // ADO.NET (Microsoft) SQLConnection, SQLCommand
            // Dapper (ORM) -> StackOverflow
            // Entity Framework Core => LINQ
            // SELECT top 30 * from Movie order by Revenue
            // movies.orderbydescnding(m=> m.Revenue).Take(30)

            var movies = this._context.Set<Movie>().OrderByDescending(m => m.Revenue).Take(30).ToList();

            return movies;
        }



        public Movie? GetMovieById(int Id)

        {

            // how about using SP to perform optimized query and then call st to perform query?????
            var trailers = this._context.Set<Trailer>().Where(trailer => trailer.MovieId == Id).ToList();
            var genres = this._context.Set<MovieGenre>().Where(moviegenre => moviegenre.MovieId == Id).ToList();
            var casts = this._context.Set<MovieCast>().Where(moviecast => moviecast.MovieId == Id).ToList();
            var movie = this._context.Set<Movie>().SingleOrDefault(m => m.Id == Id);

            movie.Casts = casts;
            movie.Genres = genres;
            movie.Trailers = trailers;


            return movie;
        }




    }
}
