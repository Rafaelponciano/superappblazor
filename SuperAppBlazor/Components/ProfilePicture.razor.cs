using Microsoft.AspNetCore.Components;

namespace SuperAppBlazor.Components;

public partial class ProfilePicture : ComponentBase
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
}