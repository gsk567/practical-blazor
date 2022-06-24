using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PracticalBlazor;
using PracticalBlazor.Services;
using System;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ISourceCodeProvider, SourceCodeProvider>();
builder.Services.AddSingleton<IGlobalDomEventService, GlobalDomEventService>();
builder.Services.AddSingleton<IGlobalNavigationService, GlobalNavigationService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var globalDomEventService = scope.ServiceProvider.GetRequiredService<IGlobalDomEventService>();
    await globalDomEventService?.InitializeAsync();

    var globalNavigationService = scope.ServiceProvider.GetRequiredService<IGlobalNavigationService>();
}

await app.RunAsync();
