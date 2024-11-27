using SuperAppBlazor.Shared.Domain;

namespace SuperAppBlazor.Shared.Services.AuthenticationService;

public interface IAuthenticationService
{
    Task<Authentication> Login(LoginUser loginUser);
    
    Task<Authentication?> Register(RegisterUser user);
}