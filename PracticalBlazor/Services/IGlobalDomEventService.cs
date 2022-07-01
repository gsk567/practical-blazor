using System;
using System.Threading.Tasks;

namespace PracticalBlazor.Services;

public interface IGlobalDomEventService
{
    event EventHandler<GlobalKeyCodePressedEventArgs> GlobalKeyCodePressed;

    Task InitializeAsync();
}