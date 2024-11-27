using Microsoft.AspNetCore.Components;
using SuperAppBlazor.Shared.Domain;

namespace SuperAppBlazor.Components;

public partial class QuickViewPopup : ComponentBase
{
    [Parameter] public SuperHero? SuperHero { get; set; }
    private SuperHero? _superHero;
    
    protected override void OnParametersSet()
    {
        _superHero = SuperHero;

    }

    public void Close()
    {
        _superHero = null;
    }
}