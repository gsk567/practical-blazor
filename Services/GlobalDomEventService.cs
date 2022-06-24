using Microsoft.JSInterop;
using PracticalBlazor.Events;
using System;
using System.Threading.Tasks;

namespace PracticalBlazor.Services;
public class GlobalDomEventService : IGlobalDomEventService, IAsyncDisposable
{
    private readonly IJSRuntime jSRuntime;
    private DotNetObjectReference<GlobalDomEventService> serviceReference;
    private IJSObjectReference module;

    public event EventHandler<GlobalKeyCodePressedEventArgs> GlobalKeyCodePressed;

    public GlobalDomEventService(IJSRuntime jSRuntime)
    {
        this.jSRuntime = jSRuntime;
        this.serviceReference = DotNetObjectReference.Create(this);
    }

    public async Task InitializeAsync()
    {
        this.module = await this.jSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/modules.js");
        await this.module.InvokeVoidAsync("initializeGlobalEventService", this.serviceReference);
    }

    [JSInvokable("OnGlobalKeyPressed")] 
    public void OnGlobalKeyPressed(string keyCode)
    {
        this.GlobalKeyCodePressed.Invoke(this, new GlobalKeyCodePressedEventArgs(keyCode));
    }

    public async ValueTask DisposeAsync()
    {
        if (this.module != null)
        {
            await this.module.DisposeAsync();
        }
    }
}