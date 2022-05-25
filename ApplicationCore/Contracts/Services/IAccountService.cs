using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IAccountService
    {


        Task<UserLoginResponseModel> RegisterUser(UserRegisterRequestModel model);
        Task<UserLoginResponseModel> CheckEmail(string email);

        Task<UserLoginResponseModel> LoginUser(UserLoginModel model);
    }
}
