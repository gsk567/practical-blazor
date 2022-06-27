using System.Threading.Tasks;

namespace PracticalBlazor.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticationStateProvider authenticationStateProvider;
    public AuthenticationService(IAuthenticationStateProvider authenticationStateProvider)
    {
        this.authenticationStateProvider = authenticationStateProvider;
    }
    public async Task<bool> LoginAsync(string email, string password)
    {
        if (email == "admin@example.com" && password == "Admin123!")
        {
            await this.authenticationStateProvider.LoginNotifyAsync(email);
            return true;
        }

        return false;
    }
 
    public async Task<bool> LogoutAsync()
    {
        await this.authenticationStateProvider.LogoutNotifyAsync();
        return true;
    }
}