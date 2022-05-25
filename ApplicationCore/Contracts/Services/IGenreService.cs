using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IGenreService
    {

        public Task<List<GenreModel>> GetGenreList();

    }
}
