using System.Threading.Tasks;

namespace PracticalBlazor.Services;

public interface IAuthenticationService
{
    Task<bool> LoginAsync(string email, string password);

    Task<bool> LogoutAsync();
}