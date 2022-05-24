using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IReviewRepository _reviewRepository;

        List<GenreModel> genres = new List<GenreModel>();
        List<CastModel> casts = new List<CastModel>();
        List<TrailerModel> trailers = new List<TrailerModel>();
        List<ReviewRequestModel> movieReviews = new List<ReviewRequestModel>();


        public MovieService(IMovieRepository movieRepository, IReviewRepository reviewRepository)
        {
            _movieRepository = movieRepository;
            _reviewRepository = reviewRepository;

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



        public async Task<PageResultSet<MovieCardModel>> GetMoviesByGenre(string genre, int pageNumber = 1, int pageSize = 30)
        {
            // call the movierepository class
            // get the entity class data and map them in to model class data
            //var movieRepo = new MovieRepository();



            var moviesByPages = await _movieRepository.GetMoviesByGenre(genre, pageNumber, pageSize);


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



        public async Task<MovieDetailsModel> GetMovieDetailsById(int id)
        {



            var movie = await this._movieRepository.GetById(id);

            var reviews = await this._reviewRepository.GetMovieReviews(id);


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

            foreach (var rev in reviews)
            {
                movieReviews.Add(new ReviewRequestModel { MovieId = rev.MovieId, UserId = rev.UserId, Rating = rev.Rating, ReviewText = rev.ReviewText });
            }


            var moviedetail = new MovieDetailsModel
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
                TagLine = movie.Tagline,
                Reviews = movieReviews,
            };
            return moviedetail;



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



        public async Task<PageResultSet<MovieCardModel>> GetMoviesByReleaseDate(int pageNumber = 1, int pageSize = 30)
        {
            var moviesByPages = await _movieRepository.GetMoviesByReleaseDate(pageNumber, pageSize);


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



    }
}