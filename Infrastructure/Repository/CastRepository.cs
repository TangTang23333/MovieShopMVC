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





        public Cast GetById(int Id)
        {

            var cast = this._context.Set<Cast>().Include(c => c.Movies).ThenInclude(c => c.Movie)
                .FirstOrDefault(c => c.Id == Id);

            return cast;
        }

        public IEnumerable<Cast> GetAll()
        {
            throw new NotImplementedException();
        }

        public Cast Add(Cast entity)
        {
            throw new NotImplementedException();
        }

        public Cast Update(Cast entity)
        {
            throw new NotImplementedException();
        }

        public Cast Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}


