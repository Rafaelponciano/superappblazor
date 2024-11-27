using SuperAppBlazor.Components.Widgets;

namespace SuperAppBlazor.Components.Pages;

public partial class Home
{
    public List<Type> Widgets { get; set; } = new List<Type>()
    {
        typeof(SuperHeroCountWidget), typeof(InboxWidget)
    };
}