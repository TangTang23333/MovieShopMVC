using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;

namespace Infrastructure.Repository
{
    public class MovieRepository : IMovieRepository

    {
        // dapper (ORM)  -> stackoverflow 
        // ado.net , MICROSOFT sql connection ,sqlcommand, 
        // ENTITY FRAMEWORK ==> LINQ 
        public List<Movie> GetTop30GlossingMovies()
        {
            // SQL Database 
            // data access logic
            // ADO.NET (Microsoft) SQLConnection, SQLCommand
            // Dapper (ORM) -> StackOverflow
            // Entity Framework Core => LINQ
            // SELECT top 30 * from Movie order by Revenue
            // movies.orderbydescnding(m=> m.Revenue).Take(30)

            var movies = new List<Movie>()
            {
                  new Movie {Id = 1, Title="Inception", PosterURL="https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"},
                  new Movie {Id = 2, Title="Inception", PosterURL="https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"},
                  new Movie {Id = 3, Title="Inception", PosterURL="https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"},
                  new Movie {Id = 4, Title="Inception", PosterURL="https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"},
                  new Movie {Id = 5, Title="Inception", PosterURL="https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"},
                  new Movie {Id = 6, Title="Inception", PosterURL="https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"},
                  new Movie {Id = 7, Title="Inception", PosterURL="https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"},
                  new Movie {Id = 8, Title="Inception", PosterURL="https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"},
                  new Movie {Id = 9, Title="Inception", PosterURL="https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"},
                  new Movie {Id = 10, Title="Inception", PosterURL="https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"},
                  new Movie {Id = 11, Title="Inception", PosterURL="https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"},
                  new Movie {Id = 12, Title="Inception", PosterURL="https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"}
            };

            return movies;
        }


    }
}
