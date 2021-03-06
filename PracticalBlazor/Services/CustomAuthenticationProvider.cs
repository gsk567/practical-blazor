using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace PracticalBlazor.Services;

public class CustomAuthenticationProvider: AuthenticationStateProvider, IAuthenticationStateProvider
{
    private const string UserEmailStorageKey = "user_email";
    
    private readonly ILocalStorageService localStorageService;
    private ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());

    public CustomAuthenticationProvider(ILocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
    }
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        string userEmail = await this.localStorageService.GetItemAsync<string>(UserEmailStorageKey);
        if (string.IsNullOrEmpty(userEmail))
        {
            var anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity() { }));
            return anonymous;
        }
        
        var userClaimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, userEmail),
            new Claim(ClaimTypes.Email, userEmail)
        }, "CustomAuthentication"));

        var user = new AuthenticationState(userClaimPrincipal);
        return user;
    }

    public async Task LoginNotifyAsync(string email)
    {
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, email),
            new Claim(ClaimTypes.Email, email)
        }, "CustomAuthentication");

        await this.localStorageService.SetItemAsync<string>(UserEmailStorageKey, email);
        
        this.claimsPrincipal = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task LogoutNotifyAsync()
    {
        await this.localStorageService.RemoveItemAsync(UserEmailStorageKey);
        this.claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}