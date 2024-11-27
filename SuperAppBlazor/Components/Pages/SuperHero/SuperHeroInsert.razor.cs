using Microsoft.AspNetCore.Components;
using SuperAppBlazor.Shared.Services.SuperHeroService;
using SuperAppBlazor.Shared.Services.SuperHeroService.Models;

namespace SuperAppBlazor.Components.Pages.SuperHero;

public partial class SuperHeroInsert : ComponentBase
{
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private ISuperHeroService? SuperHeroService { get; set; }
    
    [SupplyParameterFromForm] public InsertSuperHero InsertSuperHero { get; set; }
    
    protected override void OnInitialized()
    {
        InsertSuperHero ??= new InsertSuperHero(){ Name = "Empty" };
    }

    private async void OnSubmit(InsertSuperHero insertSuperHero)
    {
        var response = await SuperHeroService?.Insert(insertSuperHero)!;
        if (response is not null)
        {
            NavigationManager.NavigateTo("/");
        }
    }
    
    private async Task HandleValidSubmit()
    {
        OnSubmit(InsertSuperHero);
    }
}