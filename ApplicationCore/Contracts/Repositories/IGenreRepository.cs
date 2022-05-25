using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IGenreRepository : IRepository<Genre>
    {
        public Task<List<Genre>> GetGenreList();
        public Task<Genre> Add(Genre entity);
        public Task<Genre> Delete(int Id);
        public Task<List<Genre>> GetAll();
        public Task<Genre> GetById(int Id);
        public Task<Genre> Update(Genre entity);


    }
}
