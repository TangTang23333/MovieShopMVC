using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IUserRepository : IRepository<User>
    {



        Task<bool> Update(UserProfileModel userUpdated);
        Task<User> GetById(int Id);

        Task<User> GetUserByEmail(string email);
        Task<User> Update(User user);


    }
}
