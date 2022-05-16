using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface ICastRepository
    {

        public Cast GetMovies(int Id);
        public IQueryable<Cast> GetAll();
    }
}
