using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICastRepository _castRepository;
        private readonly IGenreRepository _genreRepository;

        public MovieService(IMovieRepository movieRepository, ICastRepository castRepository, IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _castRepository = castRepository;
            _genreRepository = genreRepository;
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



        public MovieDetailInfoCardModel GetMovieById(int Id)
        {
            var movie = _movieRepository.GetMovieById(Id);
            var castEntity = _castRepository.GetAll();
            var genreEntity = _genreRepository.GetAll();



            var casts = from c in movie.Casts
                        join cc in castEntity
                        on c.CastId equals cc.Id
                        select new CastModel
                        {
                            Id = cc.Id,
                            Name = cc.Name,
                            ProfilePath = cc.ProfilePath
                        };

            var genres = from g in movie.Genres
                         join gg in genreEntity
                         on g.GenreId equals gg.Id
                         select new GenreModel
                         {
                             Name = gg.Name
                         };


            return new MovieDetailInfoCardModel
            {
                Id = movie.Id,

                Title = movie.Title,
                PosterURL = movie.PosterURL,
                Overview = movie.Overview,

                Price = movie.Price,

                AvgRating = (decimal?)8.9,

                Runtime = movie.RunTime,

                Genres = genres.ToList(),/////

                Revenue = movie.Revenue,
                Budget = movie.Budget,
                ReleaseDate = movie.ReleaseDate,
                Trailers = movie.Trailers.Select(t => t.TrailerURL).ToList(),
                Casts = casts.ToList()
            };
        }


    }
}