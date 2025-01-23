using EMR_Final.Dto;

namespace EMR_Final.Services
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDto loginDto);
        //Task<bool> LogoutAsync(string username);
    }
}
