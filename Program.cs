using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PracticalBlazor;
using PracticalBlazor.Services;
using System;
using System.Net.Http;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ISourceCodeProvider, SourceCodeProvider>();
builder.Services.AddSingleton<IGlobalDomEventService, GlobalDomEventService>();
builder.Services.AddSingleton<IGlobalNavigationService, GlobalNavigationService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAuthenticationStateProvider, CustomAuthenticationProvider>();
builder.Services.AddScoped(x => x.GetRequiredService<IAuthenticationStateProvider>() as AuthenticationStateProvider);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var globalDomEventService = scope.ServiceProvider.GetRequiredService<IGlobalDomEventService>();
    await globalDomEventService?.InitializeAsync();

    var globalNavigationService = scope.ServiceProvider.GetRequiredService<IGlobalNavigationService>();
}

await app.RunAsync();
