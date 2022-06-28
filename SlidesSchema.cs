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
            typeof(BlazorIndex),
            typeof(BlazorFramework),
            typeof(BlazorHostingModels),
            typeof(BlazorComparison),
            typeof(BlazorApplications),
            typeof(ExamplesIndex),
            typeof(ExamplesComponents),
            typeof(ExamplesInheritance),
            typeof(ExamplesCommunication),
            typeof(ExamplesDynamics),
            typeof(ExamplesBridge),
            typeof(ExamplesBridgeComplex),
            typeof(ExamplesJavaScript),
            typeof(ExamplesDataFetching),
            typeof(ExamplesForms),
            typeof(ExamplesAuthentication),
            typeof(DemoIndex),
            typeof(QAIndex),
            typeof(ThankYou)
        };
    }
}
