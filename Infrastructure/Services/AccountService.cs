using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        // go to db check if email exists 
        public async Task<UserLoginResponseModel?> LoginUser(UserLoginModel userModel)
        {

            var userFound = await _userRepository.GetUserByEmail(userModel.Email);

            var userInputPsw = GetHashedPassword(userModel.Password, userFound.Salt);

            //List<MovieCardModel> favorites = new List<MovieCardModel>();
            //List<MovieCardModel> purchases = new List<MovieCardModel>();



            //foreach (var f in userFound.Favorites)
            //{
            //    favorites.Add(new MovieCardModel { Id = f.MovieId, Title = f.Movie.Title, PosterURL = f.Movie.PosterURL });
            //}


            //foreach (var p in userFound.Purchases)
            //{
            //    purchases.Add(new MovieCardModel { Id = p.MovieId, Title = p.Movie.Title, PosterURL = p.Movie.PosterURL });
            //}


            if (userInputPsw == userFound.HashedPassword)
            {


                return new UserLoginResponseModel
                {
                    Id = userFound.Id,
                    FirstName = userFound.FirstName,
                    LastName = userFound.LastName,
                    Email = userFound.Email,
                    DateOfBirth = userFound.DateOfBirth,
                    //LastLoginDateTime = DateTime.Now,
                    //Favorites = favorites,
                    //Purchased = purchases

                };
            }


            //userFound.AccessFailedCount += 1;
            //if (userFound.AccessFailedCount == 3)
            //{
            //    userFound.IsLocked = true;
            //}

            //var updateUser = await _userRepository.Update(userFound);
            return null;


        }




        private string GetRandomSalt()
        {
            var randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }


        private string GetHashedPassword(string password, string salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
           password,
           Convert.FromBase64String(salt),
           KeyDerivationPrf.HMACSHA512,
           10000,
           256 / 8));


        }

        public async Task<UserLoginResponseModel> RegisterUser(UserRegisterRequestModel user)
        {

            var existed = await CheckEmail(user.Email);
            // check if email is already registered in db!!!!
            if (existed != null)
            {
                throw new Exception("Email has already been registered, please log in!");
            }


            var salt = GetRandomSalt();
            var hashedPassword = GetHashedPassword(user.Password, salt);


            var newUser = new User
            {
                FirstName = user.Firstname,
                LastName = user.Lastname,
                HashedPassword = hashedPassword,
                Salt = salt,
                Email = user.Email,
                DateOfBirth = Convert.ToDateTime(user.DateOfBirth),

            };


            var addUser = await this._userRepository.Add(newUser);


            if (addUser.Id > 0)
            {

                var response = new UserLoginResponseModel
                {
                    Id = addUser.Id,

                    FirstName = addUser.FirstName,

                    LastName = addUser.LastName,
                    Email = addUser.Email,

                    DateOfBirth = addUser.DateOfBirth
                };


                return response;
            }

            throw new Exception("Registeration is not successful!");

        }
        public async Task<UserLoginResponseModel> CheckEmail(string email)
        {
            var userFound = await _userRepository.GetUserByEmail(email);

            if (userFound != null)
            {
                var response = new UserLoginResponseModel
                {
                    Id = userFound.Id,

                    FirstName = userFound.FirstName,

                    LastName = userFound.LastName,
                    Email = userFound.Email,

                    DateOfBirth = userFound.DateOfBirth
                };

                return response;
            }
            return null;
        }

    }



}
