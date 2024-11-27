using Microsoft.AspNetCore.Components;

namespace SuperAppBlazor.Components.Widgets;

public partial class InboxWidget : ComponentBase
{
    public int MessageCount { get; set; } = 0;

    protected override void OnInitialized()
    {
        MessageCount = new Random().Next(1, 100);
    }
}