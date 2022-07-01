using System;

namespace PracticalBlazor.Services;

public class GlobalKeyCodePressedEventArgs : EventArgs
{
    public GlobalKeyCodePressedEventArgs(string keyCode)
    {
        KeyCode = keyCode;
    }

    public string KeyCode { get; }
}