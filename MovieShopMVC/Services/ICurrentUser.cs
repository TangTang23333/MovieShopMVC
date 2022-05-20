namespace MovieShopMVC.Services
{
    public interface ICurrentUser
    {

        int? UserId { get; }
        bool IsAdmin { get; }
        bool IsAuthenticated { get; }
        string Email { get; }
        string Firstname { get; }
        string Lastname { get; }

        List<string> Roles { get; }


    }
}
