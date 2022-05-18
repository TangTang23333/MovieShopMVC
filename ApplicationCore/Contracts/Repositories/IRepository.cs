namespace ApplicationCore.Contracts.Repositories
{
    public interface IRepository<T> where T : class
    {





        Task<T> GetById(int Id);

        Task<List<T>> GetAll();

        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int Id);



    }

}
