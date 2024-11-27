using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;

namespace SuperAppBlazor.Shared.Domain;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal _anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
    private ClaimsPrincipal _currentUser;
    
    public CustomAuthenticationStateProvider()
    {
        _currentUser = _anonymousUser;
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(new AuthenticationState(_currentUser));
    }

    public Task<bool> AuthenticateUserAsync(Authentication authUser)
    {
        if (authUser is not null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, authUser.FirstName + " " + authUser.LastName),
                new Claim(ClaimTypes.Email, authUser.Email)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            _currentUser = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));

            return Task.FromResult(true);
        }
        else
        {
            MarkUserAsLoggedOut();
        }

        return Task.FromResult(false);
    }

    public void MarkUserAsLoggedOut()
    {
        _currentUser = _anonymousUser;
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymousUser)));
    }
}