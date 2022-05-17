namespace ApplicationCore.Contracts.Repositories
{
    public interface IRepository<T> where T : class
    {





        T GetById(int Id);

        IEnumerable<T> GetAll();

        T Add(T entity);
        T Update(T entity);
        T Delete(int Id);



    }

}
