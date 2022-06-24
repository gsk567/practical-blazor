using PracticalBlazor.Pages;
using System;
using System.Collections.Generic;
using Index = PracticalBlazor.Pages.Index;

namespace PracticalBlazor
{
    public static class SlidesSchema
    {
        public static readonly IReadOnlyList<Type> OrderedSlidesTypes = new[]
        {
            typeof(Index),
            typeof(WhoAmI),
            typeof(Agenda),
            typeof(PurposeIndex),
            typeof(PurposeContent),
            typeof(ExampleBridge),
            typeof(ExampleBridgeComplex),
            typeof(ThankYou)
        };
    }
}
