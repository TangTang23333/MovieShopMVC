using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IAccountService
    {


        Task<bool> RegisterUser(UserRegisterRequestModel model);


        Task<UserLoginResponseModel> LoginUser(UserLoginModel model);
    }
}
