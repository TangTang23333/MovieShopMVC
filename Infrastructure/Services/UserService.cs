using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private IPurchaseRepository _purchaseRepository;
        public UserService(IPurchaseRepository purchaseRepository)
        {
            this._purchaseRepository = purchaseRepository;
        }


        public async Task<List<PurchaseDetailModel>> GetPurchasesByUserId(int userId)
        {


            var purchases = await _purchaseRepository.GetPurchaseByUserId(userId);

            List<PurchaseDetailModel> movies = new List<PurchaseDetailModel>();

            foreach (var purchase in purchases)
            {
                movies.Add(new PurchaseDetailModel
                {
                    MovieId = purchase.MovieId,
                    Title = purchase.Movie.Title,
                    PosterURL = purchase.Movie.PosterURL,
                    PurchaseNumber = purchase.PurchaseNumber.ToString(),
                    PurchaseDate = purchase.PurchaseDateTime,
                    PurchasePrice = purchase.TotalPrice
                });
            }


            return movies;
        }
    }
}
