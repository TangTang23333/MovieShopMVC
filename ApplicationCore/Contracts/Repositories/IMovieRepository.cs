using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {

        Task<List<Movie>> GetTop30GlossingMovies();
        Task<PageResultSet<MovieDetailsModel>> GetMoviesByReleaseDate(int pageNumber, int pageSize);
        Task<Movie> GetById(int id);

        Task<List<Review>> GetReviews(int Id);
        // totalcount, pagesize, pagenumber, totalpages
        //Task<(List<Movie>, int totalCount, int totalPages)> GetMoviesByGenre(string genre, int pageSize = 30, int pageNumber = 1);
        Task<PageResultSet<Movie>> GetMoviesByGenre(string genre, int pageNumber = 1, int pageSize = 30);
        Task<PageResultSet<Movie>> GetMoviesByGenreId(int genre, int pageNumber = 1, int pageSize = 30);

        Task<List<MovieCardModel>> GetTopRated30();
        Task<MovieCreateRequestModel> CreateNewMovie(MovieCreateRequestModel model);

        Task<MovieCreateRequestModel> UpdateMovie(MovieCreateRequestModel model);
    }
}
