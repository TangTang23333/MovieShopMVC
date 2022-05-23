using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
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
            throw new NotImplementedException();
        }



        public async Task<User> Update(User userUpdated)
        {
            this._context.Set<User>().Update(userUpdated);
            await this._context.SaveChangesAsync();

            return userUpdated;
        }
    }
}
