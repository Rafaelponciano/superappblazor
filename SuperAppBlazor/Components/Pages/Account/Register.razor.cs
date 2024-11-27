using Microsoft.AspNetCore.Components;
using SuperAppBlazor.Shared.Domain;
using SuperAppBlazor.Shared.Services.AuthenticationService;

namespace SuperAppBlazor.Components.Pages.Account;

public partial class Register : ComponentBase
{
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private IAuthenticationService? AuthenticationService { get; set; }
    [Inject] private CustomAuthenticationStateProvider CustomAuthenticationStateProvider { get; set; }
    
    [SupplyParameterFromForm] public RegisterUser RegisterUser { get; set; }
    
    protected override void OnInitialized()
    {
        RegisterUser ??= new RegisterUser();
    }

    private async void OnSubmit(RegisterUser user)
    {
        var response = await AuthenticationService?.Register(user)!;
        var isValid = await CustomAuthenticationStateProvider.AuthenticateUserAsync(response);
        if (isValid)
        {
            NavigationManager.NavigateTo("/");
        }
    }
    
    private async Task HandleValidSubmit()
    {
        OnSubmit(RegisterUser);
    }
}