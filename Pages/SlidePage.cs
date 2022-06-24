using Essentials.Extensions;
using Microsoft.AspNetCore.Components;
using PracticalBlazor.Models;

namespace PracticalBlazor.Pages
{
    public abstract class SlidePage : ComponentBase
    {
        protected string GetBrandedTitle(string title) => $"{title} | Scalefocus";
    }
}
