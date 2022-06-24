using System;
using Essentials.Extensions;
using Microsoft.AspNetCore.Components;

namespace PracticalBlazor.Models
{
    public class Slide
    {
        public string Title { get; set; }

        public SlideType Type { get; set; }

        public Type PageType { get; set; }

        public string Route => PageType?.GetAttribute<RouteAttribute>()?.Template;
    }
}
