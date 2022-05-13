using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepository
    {

        List<Movie> GetTop30GlossingMovies();
    }
}
