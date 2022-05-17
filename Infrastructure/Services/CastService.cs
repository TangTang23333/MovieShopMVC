using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;
        private readonly IMovieRepository _movieRepository;
        public List<MovieCardModel> movies = new List<MovieCardModel>();
        public CastService(ICastRepository castRepository, IMovieRepository movieRepository)
        {
            this._castRepository = castRepository;
            this._movieRepository = movieRepository;
        }


        public CastDetailsModel GetById(int Id)
        {
            var cast = _castRepository.GetById(Id);



            foreach (var m in cast.Movies)
            {

                movies.Add(
                    new MovieCardModel
                    {
                        Id = m.Movie.Id,
                        PosterURL = m.Movie.PosterURL,
                        Title = m.Movie.Title
                    });
            }

            var castdetail = new CastDetailsModel
            {
                Id = cast.Id,
                Name = cast.Name,
                Gender = cast.Gender,
                TmdbUrl = cast.TmdbUrl,
                ProfilePath = cast.ProfilePath,
                Movies = movies

            };

            return castdetail;

        }
    }
}
