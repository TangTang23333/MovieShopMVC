using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IMovieService _movieService;
        private readonly IReviewRepository _reviewRepository;

        List<GenreModel> genres = new List<GenreModel>();
        List<CastModel> casts = new List<CastModel>();
        List<TrailerModel> trailers = new List<TrailerModel>();
        List<ReviewRequestModel> movieReviews = new List<ReviewRequestModel>();

        public UserService(IPurchaseRepository purchaseRepository,
            IFavoriteRepository favoriteRepository,
            ICartRepository cartRepository,
            IMovieService movieService,
            IReviewRepository reviewRepository,
            IMovieRepository movieRepository,
            IUserRepository userRepository
            )
        {
            this._purchaseRepository = purchaseRepository;
            this._favoriteRepository = favoriteRepository;
            this._cartRepository = cartRepository;
            this._movieService = movieService;
            this._reviewRepository = reviewRepository;
            this._movieRepository = movieRepository;
            this._userRepository = userRepository;
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



        public async Task<List<FavoriteDetailModel>> GetFavoritesByUserId(int userId)
        {


            var favorites = await _favoriteRepository.GetFavoritesByUserId(userId);

            List<FavoriteDetailModel> movies = new List<FavoriteDetailModel>();

            foreach (var favorite in favorites)
            {
                movies.Add(new FavoriteDetailModel
                {
                    UserId = userId,
                    Id = favorite.Id,
                    MovieId = favorite.MovieId,
                    Title = favorite.Movie.Title,
                    PosterURL = favorite.Movie.PosterURL,
                    Price = favorite.Movie.Price
                });
            }


            return movies;
        }

        public async Task<List<CartDetailModel>> GetCartByUserId(int userId)
        {
            var cart = await this._cartRepository.GetByUser(userId);

            var cartItems = new List<CartDetailModel>();
            foreach (var c in cart)
            {
                cartItems.Add(new CartDetailModel
                {
                    UserId = c.UserId,
                    MovieId = c.MovieId,
                    PosterURL = c.Movie.PosterURL,
                    Title = c.Movie.Title,
                    Price = c.Movie.Price

                });
            }

            return cartItems;
        }


        public async Task<bool> IsMoviePurchased(int userId, int movieId)
        {
            return await this._purchaseRepository.IsMoviePurcahsed(userId, movieId);


        }


        public async Task<bool> IsMovieFavorite(int userId, int id)
        {
            return await this._favoriteRepository.IsMovieFavorite(userId, id);
        }
        public async Task<bool> AddMovieReview(ReviewRequestModel request)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieDetailByUserModel> GetMovieDetailByIdByUser(int userId, int movieId)
        {
            var movie = await _movieRepository.GetById(movieId);

            var reviews = await this._reviewRepository.GetMovieReviews(movieId);
            var userReivew = await this._reviewRepository.GetMovieReview(userId, movieId);


            decimal rating = 0;

            if (reviews != null)
            {
                rating = Math.Round(reviews.Average(e => e.Rating), 1);
            }


            foreach (var cast in movie.Casts)
            {
                casts.Add(new CastModel { Character = cast.Character, Id = cast.CastId, ProfilePath = cast.Cast.ProfilePath, Name = cast.Cast.Name });
            }

            foreach (var genre in movie.Genres)
            {
                genres.Add(new GenreModel { Id = genre.Genre.Id, Name = genre.Genre.Name });
            }

            foreach (var trailer in movie.Trailers)
            {
                trailers.Add(new TrailerModel { Id = trailer.Id, Name = trailer.Name, TrailerURL = trailer.TrailerURL });
            }

            foreach (var rev in reviews)
            {
                movieReviews.Add(new ReviewRequestModel { MovieId = rev.MovieId, UserId = rev.UserId, Rating = rev.Rating, ReviewText = rev.ReviewText });
            }


            var movieDetail = new MovieDetailByUserModel
            {
                Id = movie.Id,
                Title = movie.Title,
                PosterURL = movie.PosterURL,
                Overview = movie.Overview,
                Price = movie.Price,
                AvgRating = rating,
                Runtime = movie.RunTime,
                Revenue = movie.Revenue,
                Budget = movie.Budget,
                ReleaseDate = movie.ReleaseDate,
                Genres = genres,
                Casts = casts,
                Trailers = trailers,
                TagLine = movie.Tagline,
                Reviews = movieReviews,
                // user part could be null
                UserId = userId,
                IsFavorite = await IsMovieFavorite(userId, movieId),
                IsPurchased = await IsMoviePurchased(userId, movieId)




            };

            if (userReivew != null)
            {
                movieDetail.Review = new ReviewRequestModel { MovieId = movie.Id, UserId = userId, Rating = userReivew.Rating, ReviewText = userReivew.ReviewText };
            }
            return movieDetail;
        }

        public async Task<bool> AddPurchaseFromCart(List<CartDetailModel> purchases)
        {
            try
            {

                foreach (var item in purchases)
                {
                    await this._purchaseRepository.AddPurchaseToUserId(item);

                }
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("purchase is not successful, please retry later!");
                return false;
            }
        }

        public async Task<Purchase> CreatePurchaseAPI(PurchaseRequestModel purchase)
        {

            try
            {
                return await this._purchaseRepository.CreatePurchaseAPI(purchase);
            }
            catch (Exception ex)
            {

                throw new Exception("Purchase is not successful, please try again later!");

            }

        }
        public async Task<UserProfileModel> GetUserProfile(int id)
        {
            var user = await this._userRepository.GetById(id);
            var profile = new UserProfileModel
            {
                Id = user.Id,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                DateOfBirth = (DateTime)user.DateOfBirth,
                Email = user.Email,
                Phone = user.PhoneNumber
            };

            return profile;
        }



        public async Task<bool> UpdateUser(UserProfileModel user)
        {
            return await this._userRepository.Update(user);
        }
    }
}