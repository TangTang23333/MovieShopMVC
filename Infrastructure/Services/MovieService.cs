using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        List<GenreModel> genres = new List<GenreModel>();
        List<CastModel> casts = new List<CastModel>();
        List<TrailerModel> trailers = new List<TrailerModel>();

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;




        }



        public async Task<List<MovieCardModel>> GetTop30GlossingMovies()
        {
            // call the movierepository class
            // get the entity class data and map them in to model class data
            //var movieRepo = new MovieRepository();
            var movies = await _movieRepository.GetTop30GlossingMovies();




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



        public async Task<PageResultSet<MovieCardModel>> GetMoviesByGenre(string genre, int pageSize, int pageNumber)
        {
            // call the movierepository class
            // get the entity class data and map them in to model class data
            //var movieRepo = new MovieRepository();



            var moviesByPages = await _movieRepository.GetMoviesByGenre(genre);  // GetMoviesByGenre(string genre, int pageSize = 30, int pageNumber = 1)


            //PageResultSet<Movie>(movies, pageNumber, pageSize, totalMovieCount);
            var movieCards = new List<MovieCardModel>();



            foreach (var movie in moviesByPages.Data)
            {
                movieCards.Add(new MovieCardModel
                {
                    Id = movie.Id,
                    PosterURL = movie.PosterURL,
                    Title = movie.Title
                });
            }



            return new PageResultSet<MovieCardModel>(movieCards, pageNumber, pageSize, moviesByPages.Count);
        }



        public async Task<MovieDetailsModel> GetMovieDetailsById(int Id)
        {



            var movie = await _movieRepository.GetById(Id);

            var reviews = await _movieRepository.GetReviews(Id);
            decimal rating = 0;

            if (reviews is null)
            {
                rating = Math.Round(reviews.Average(e => e.Rating), 1);
            }




            foreach (var cast in movie.Casts)
            {
                casts.Add(new CastModel { Character = cast.Character, Id = cast.CastId, ProfilePath = cast.Cast.ProfilePath, Name = cast.Cast.Name });
            }

            foreach (var genre in movie.Genres)
            {
                genres.Add(new GenreModel { Id = genre.Genre.Id, Name = genre.Genre.Name });
            }

            foreach (var trailer in movie.Trailers)
            {
                trailers.Add(new TrailerModel { Id = trailer.Id, Name = trailer.Name, TrailerURL = trailer.TrailerURL });
            }




            var movieDetail = new MovieDetailsModel
            {
                Id = movie.Id,
                Title = movie.Title,
                PosterURL = movie.PosterURL,
                Overview = movie.Overview,
                Price = movie.Price,
                AvgRating = rating,
                Runtime = movie.RunTime,
                Revenue = movie.Revenue,
                Budget = movie.Budget,
                ReleaseDate = movie.ReleaseDate,
                Genres = genres,
                Casts = casts,
                Trailers = trailers,
                TagLine = movie.Tagline


            };
            return movieDetail;



        }

        public async Task<List<GenreModel>> GetGenreList()
        {
            var genresTb = await _movieRepository.GetGenreList();

            var genres = new List<GenreModel>();

            foreach (var genre in genresTb)
            {
                genres.Add(new GenreModel { Id = genre.Id, Name = genre.Name });
            }


            return genres;
        }


    }
}