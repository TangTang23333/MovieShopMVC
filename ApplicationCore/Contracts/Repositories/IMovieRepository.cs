using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {

        List<Movie> GetTop30GlossingMovies();

        Movie GetById(int id);

        IEnumerable<Review> GetReviews(int Id);
    }
}
