using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        // 
        public List<MovieCardModel> GetTop30GlossingMovies();


        public MovieDetailInfoCardModel GetMovieById(int Id);
    }
}
