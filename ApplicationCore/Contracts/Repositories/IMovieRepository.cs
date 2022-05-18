using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {

        Task<List<Movie>> GetTop30GlossingMovies();

        Task<Movie> GetById(int id);

        Task<List<Review>> GetReviews(int Id);
        // totalcount, pagesize, pagenumber, totalpages
        //Task<(List<Movie>, int totalCount, int totalPages)> GetMoviesByGenre(string genre, int pageSize = 30, int pageNumber = 1);
        Task<PageResult<Movie>> GetMoviesByGenre(string genre, int pageSize = 30, int pageNumber = 1);
        Task<List<Genre>> GetGenreList();

    }
}
