using Microsoft.AspNetCore.Components;
using SuperAppBlazor.Shared.Services.SuperHeroService;

namespace SuperAppBlazor.Components.Pages.SuperHero;

public partial class SuperHeroOverview : ComponentBase
{
    [Inject] private ISuperHeroService? SuperHeroService { get; set; }
    public List<Shared.Domain.SuperHero>? SuperHeroes { get; set; }
    private Shared.Domain.SuperHero _selectedSuperHero;
    private string Title = "Lista de Super Herois";

    protected async override Task OnInitializedAsync()
    {
        SuperHeroes = await SuperHeroService.GetAll();
    }
    
    public void ShowQuickViewPopup(Shared.Domain.SuperHero superHero)
    {
        _selectedSuperHero = superHero;
    }
}