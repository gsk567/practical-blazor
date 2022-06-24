using Microsoft.AspNetCore.Components;

namespace PracticalBlazor.Components.Features
{
    public class Animal : ComponentBase
    {
        [Parameter]
        public string Name { get; set; }
    }
}
