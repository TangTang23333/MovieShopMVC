using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class GenreRepository : IGenreRepository
    {

        private readonly MovieShopDbContext _context;
        public GenreRepository(MovieShopDbContext context)
        {
            this._context = context;
        }

        public IQueryable<Genre> GetAll()
        {
            return this._context.Set<Genre>();
        }
    }
}
