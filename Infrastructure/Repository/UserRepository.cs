using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task<User> Add(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
