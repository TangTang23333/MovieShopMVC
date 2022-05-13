using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Infrastructure.Repository;

namespace Infrastructure.Services
{
    public class MovieTestService : IMovieService
    {


        public List<MovieCardModel> GetTop30GlossingMovies()
        {// call the movierepository class
            // get the entity class data and map them in to model class data
            var movieRepo = new MovieRepository();
            var movies = movieRepo.GetTop30GlossingMovies();

            var movieCards = new List<MovieCardModel>();

            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardModel
                {
                    Id = movie.Id,
                    PosterURL = movie.PosterURL,
                    Title = movie.Title
                });
            }

            return movieCards;
        }
    }
}
