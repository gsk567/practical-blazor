using Microsoft.AspNetCore.Components;

namespace PracticalBlazor.Components.Features
{
    public abstract class Animal : ComponentBase
    {
        [Parameter]
        public string Name { get; set; }
    }
}
