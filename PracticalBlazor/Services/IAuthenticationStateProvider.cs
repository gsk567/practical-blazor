using System.Threading.Tasks;

namespace PracticalBlazor.Services;

public interface IAuthenticationStateProvider
{
    Task LoginNotifyAsync(string email);

    Task LogoutNotifyAsync();
}