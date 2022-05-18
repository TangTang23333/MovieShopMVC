using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;

namespace Infrastructure.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        public Task<Purchase> Add(Purchase entity)
        {
            throw new NotImplementedException();
        }

        public Task<Purchase> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Purchase>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Purchase> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Purchase> Update(Purchase entity)
        {
            throw new NotImplementedException();
        }
    }
}
