using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        // 
        public Task<List<MovieCardModel>> GetTop30GlossingMovies();


        public Task<MovieDetailsModel> GetMovieDetailsById(int Id);
        public Task<PageResultSet<MovieCardModel>> GetMoviesByGenre(string genre, int pageSize = 30, int pageNumber = 1);

        public Task<List<GenreModel>> GetGenreList();
    }
}
