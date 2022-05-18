using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class CastRepository : ICastRepository
    {

        private readonly MovieShopDbContext _context;
        public CastRepository(MovieShopDbContext context)
        {
            this._context = context;
        }





        public Task<Cast> GetById(int Id)
        {

            var cast = this._context.Set<Cast>().Include(c => c.Movies).ThenInclude(c => c.Movie)
                .FirstOrDefaultAsync(c => c.Id == Id);

            return cast;
        }

        public Task<Cast> Add(Cast entity)
        {
            throw new NotImplementedException();
        }



        public Task<Cast> Delete(int Id)
        {
            throw new NotImplementedException();
        }



        public Task<List<Cast>> GetAll()
        {
            throw new NotImplementedException();
        }


        public Task<Cast> Update(Cast entity)
        {
            throw new NotImplementedException();
        }


    }
}


