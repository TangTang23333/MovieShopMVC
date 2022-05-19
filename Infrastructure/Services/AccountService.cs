using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Text;

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
        public async Task<UserLoginResponseModel> LoginUser(UserLoginModel userModel)
        {

            var userFound = await _userRepository.GetUserByEmail(userModel.Email);

            var userInputPsw = GetHashedPassword(userModel.Password, Encoding.ASCII.GetBytes(userFound.Salt));

            List<MovieCardModel> favorites = new List<MovieCardModel>();
            List<MovieCardModel> purchases = new List<MovieCardModel>();



            foreach (var f in userFound.Favorites)
            {
                favorites.Add(new MovieCardModel { Id = f.MovieId, Title = f.Movie.Title, PosterURL = f.Movie.PosterURL });
            }


            foreach (var p in userFound.Purchases)
            {
                purchases.Add(new MovieCardModel { Id = p.MovieId, Title = p.Movie.Title, PosterURL = p.Movie.PosterURL });
            }


            if (userInputPsw == userFound.HashedPassword)
            {


                return new UserLoginResponseModel
                {

                    FirstName = userFound.FirstName,
                    LastName = userFound.LastName,
                    LastLoginDateTime = DateTime.Now,
                    Favorites = favorites,
                    Purchased = purchases

                };
            }
            else
            {

                userFound.AccessFailedCount += 1;
                if (userFound.AccessFailedCount == 3)
                {
                    userFound.IsLocked = true;
                }

                var updateUser = await _userRepository.Update(userFound);

                return new UserLoginResponseModel
                {
                    Id = 0
                };
            }

        }




        private byte[] GetRandomSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            return salt;
        }


        private string GetHashedPassword(string password, byte[] salt)
        {
            Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

            return password;
        }

        public async Task<bool> RegisterUser(UserRegisterRequestModel user)
        {


            // check if email is already registered in db!!!!
            var userFound = await _userRepository.GetUserByEmail(user.Email);

            if (userFound != null)
            {
                return false;
            }


            var salt = GetRandomSalt();
            var hashedPassword = GetHashedPassword(user.Password, salt);


            var newUser = new User
            {
                FirstName = user.Firstname,
                LastName = user.Lastname,
                HashedPassword = hashedPassword,
                Salt = salt.ToString(),
                Email = user.Email,
                DateOfBirth = Convert.ToDateTime(user.DateOfBirth),

            };


            var addUser = _userRepository.Add(newUser);


            if (addUser.Id > 0)
            {
                return true;
            }

            return false;

        }


    }



}
