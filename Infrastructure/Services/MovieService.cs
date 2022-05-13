using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }



        public List<MovieCardModel> GetTop30GlossingMovies()
        {
            // call the movierepository class
            // get the entity class data and map them in to model class data
            //var movieRepo = new MovieRepository();
            var movies = _movieRepository.GetTop30GlossingMovies();

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