using Microsoft.AspNetCore.Components;
using SuperAppBlazor.Shared.Services.SuperHeroService;

namespace SuperAppBlazor.Components.Pages.SuperHero;

public partial class SuperHeroDetail : ComponentBase
{
    [Inject] private ISuperHeroService? SuperHeroService { get; set; }
    [Parameter] public int SuperHeroId { get; set; }
    public Shared.Domain.SuperHero SuperHero { get; set; } = new Shared.Domain.SuperHero(){Name = "Empty"};
    private void ChangeStateOfActivity()
    {
        SuperHero.IsActive = !SuperHero.IsActive;
        SuperHeroService.Update(SuperHero);
    }

    protected async override Task OnInitializedAsync()
    {
        SuperHero = await SuperHeroService.GetById(SuperHeroId);
    }
}