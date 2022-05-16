using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class MovieTestService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieTestService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }


        public List<MovieCardModel> GetTop30GlossingMovies()
        {// call the movierepository class
         // get the entity class data and map them in to model class data


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




        MovieDetailInfoCardModel IMovieService.GetMovieById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
