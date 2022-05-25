using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private readonly MovieShopDbContext _context;
        public GenreRepository(MovieShopDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<Genre>> GetGenreList()
        {
            return await this._context.Set<Genre>().ToListAsync();

        }

        Task<Genre> Add(Genre entity)
        {
            throw new NotImplementedException();
        }



        Task<Genre> Delete(int Id)
        {
            throw new NotImplementedException();
        }



        Task<List<Genre>> GetAll()
        {
            throw new NotImplementedException();
        }



        Task<Genre> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        Task<Genre> Update(Genre entity)
        {
            throw new NotImplementedException();
        }

    }
}
