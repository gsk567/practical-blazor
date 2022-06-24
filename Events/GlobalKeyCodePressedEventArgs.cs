using System;

namespace PracticalBlazor.Events;

public class GlobalKeyCodePressedEventArgs : EventArgs
{
    public GlobalKeyCodePressedEventArgs(string keyCode)
    {
        KeyCode = keyCode;
    }

    public string KeyCode { get; }
}