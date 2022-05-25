using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            this._genreRepository = genreRepository;
        }

        public async Task<List<GenreModel>> GetGenreList()
        {
            var genres = await this._genreRepository.GetGenreList();

            var res = new List<GenreModel>();

            foreach (var genre in genres)
            {
                res.Add(new GenreModel { Id = genre.Id, Name = genre.Name });
            }


            return res;
        }
    }


}
