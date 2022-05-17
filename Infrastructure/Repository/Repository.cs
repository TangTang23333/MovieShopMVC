using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
namespace Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class


    {

        protected readonly MovieShopDbContext _context;

        public Repository(MovieShopDbContext context)
        {
            this._context = context;
        }

        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public T Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }



}
