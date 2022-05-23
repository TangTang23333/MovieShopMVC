using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly MovieShopDbContext _context;

        public CartRepository(MovieShopDbContext context)
        {
            this._context = context;
        }
        public async Task<bool> AddCartToUserId(CartDetailModel entity)
        {
            var cartItem = new CartItem
            {

                UserId = entity.UserId,
                MovieId = entity.MovieId
            };

            try
            {
                await _context.Set<CartItem>().AddAsync(cartItem);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Add to cart is not successful");
                return false;
            }


        }

        public async Task<bool> ClearCartToUserId(int userId)
        {
            try
            {
                var c = this._context.Set<CartItem>().Where(c => c.UserId == userId);
                this._context.Set<CartItem>().RemoveRange(c);
                await this._context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Clear cart is not successful");
                return false;
            }
        }
        public async Task<bool> DeleteCartToUserId(int userId, int movieId)
        {


            try
            {
                var c = await this._context.Set<CartItem>().FirstOrDefaultAsync(c => c.UserId == userId && c.MovieId == movieId);
                this._context.Set<CartItem>().Remove(c);
                await this._context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Delete cart item is not successful");
                return false;
            }
        }
        public Task<CartItem> Delete(int Id)
        {
            throw new NotImplementedException();
        }


        public Task<CartItem> Add(CartItem entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<CartItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CartItem> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CartItem>> GetByUser(int userId)
        {



            var cart = await _context.Set<CartItem>()
                .Include(c => c.User)
                .Include(c => c.Movie)
                .Where(c => c.UserId == userId).ToListAsync();

            return cart;
        }


        public Task<CartItem> Update(CartItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
