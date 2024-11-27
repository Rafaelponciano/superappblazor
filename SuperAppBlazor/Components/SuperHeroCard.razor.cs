using Microsoft.AspNetCore.Components;

namespace SuperAppBlazor.Components;

public partial class SuperHeroCard : ComponentBase
{
    [Parameter] public Shared.Domain.SuperHero SuperHero { get; set; } = default!;
    
    [Parameter] public EventCallback<Shared.Domain.SuperHero> SuperHeroQuickViewClicked { get; set; }

    protected override void OnInitialized()
    {
        if (string.IsNullOrEmpty(SuperHero.LastName))
        {
            throw new ArgumentException("SuperHero.LastName is required");
        }
    }
    
}