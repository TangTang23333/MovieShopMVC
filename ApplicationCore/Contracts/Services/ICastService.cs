
using ApplicationCore.Models;
namespace ApplicationCore.Contracts.Services
{
    public interface ICastService


    {

        Task<CastDetailsModel> GetById(int Id);

    }
}
