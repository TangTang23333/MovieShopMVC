using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IGenreRepository
    {


        public IQueryable<Genre> GetAll();
    }
}
