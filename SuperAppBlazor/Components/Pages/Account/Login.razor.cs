using Microsoft.AspNetCore.Components;
using SuperAppBlazor.Shared.Domain;
using SuperAppBlazor.Shared.Services.AuthenticationService;

namespace SuperAppBlazor.Components.Pages.Account;

public partial class Login : ComponentBase
{
    [Inject] private NavigationManager? NavigationManager { get; set; }
    [Inject] private IAuthenticationService? AuthenticationService { get; set; }
    
    [Inject] private CustomAuthenticationStateProvider CustomAuthenticationStateProvider { get; set; }  
    [SupplyParameterFromForm] public LoginUser LoginUser { get; set; }

    public bool IsRegister { get; set; } = false;
    private void ChangeStateOfPage()
    {
        IsRegister = !IsRegister;
    }

    protected override void OnInitialized()
    {
        LoginUser ??= new LoginUser();
    }

    private async void OnSubmit(LoginUser login)
    {
        var response = await AuthenticationService?.Login(login)!;
        var isValid = await CustomAuthenticationStateProvider.AuthenticateUserAsync(response);
        if (isValid)
        {
           NavigationManager.NavigateTo("/");
        }
    }
    
    private async Task HandleValidSubmit()
    {
        OnSubmit(LoginUser);
    }
}