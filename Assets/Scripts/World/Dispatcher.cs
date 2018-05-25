using System;
using System.Collections.Generic;
using System.Text;

public class Dispatcher
{
    public delegate void EventHandler(byte[] data);

    private static Dictionary<uint, EventHandler> _maps = new Dictionary<uint, EventHandler>();

    public static void Bind(uint type, EventHandler eventHandler)
    {
        _maps.Add(type, eventHandler);
    }

    public static void Handle(uint type, byte[] data)
    {
        _maps[type].Invoke(data);
    }
}