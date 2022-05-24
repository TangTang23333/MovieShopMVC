using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly MovieShopDbContext _context;

        public UserRepository(MovieShopDbContext context) : base(context)
        {

            this._context = context;

        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await this._context.Set<User>().Include(u => u.Favorites).ThenInclude(f => f.Movie)
        .Include(u => u.Purchases).ThenInclude(p => p.Movie).FirstOrDefaultAsync(u => u.Email == email);

            return user;
        }

        public async Task<User> Add(User entity)
        {


            await this._context.Set<User>().AddAsync(entity);
            await this._context.SaveChangesAsync();

            return entity;
        }

        public async Task<User> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetById(int Id)
        {
            return await this._context.Set<User>().FirstOrDefaultAsync(u => u.Id == Id);

        }



        public async Task<bool> Update(UserProfileModel userUpdated)
        {
            try
            {
                var user = await this._context.Set<User>().FirstOrDefaultAsync(u => u.Id == userUpdated.Id);
                user.FirstName = userUpdated.Firstname;
                user.LastName = userUpdated.Lastname;
                user.Email = userUpdated.Email;
                user.PhoneNumber = userUpdated.Phone;
                user.DateOfBirth = userUpdated.DateOfBirth;
                await this._context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("update is failed! Please try again!");
            }
        }
    }
}
