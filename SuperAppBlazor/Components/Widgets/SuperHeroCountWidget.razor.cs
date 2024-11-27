using Microsoft.AspNetCore.Components;
using SuperAppBlazor.Shared.Services.SuperHeroService;

namespace SuperAppBlazor.Components.Widgets;

public partial class SuperHeroCountWidget : ComponentBase
{
    [Inject] private ISuperHeroService? SuperHeroService { get; set; }
    public int SuperHeroCounter { get; set; }

    protected async override void OnInitialized()
    {
        var superHeroes = await SuperHeroService.GetAll();
        SuperHeroCounter = superHeroes?.Count ?? 0;
    }
}