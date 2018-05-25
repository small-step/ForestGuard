using System;
using System.Collections.Generic;
using System.Text;

public enum EventType : uint
{
    KeepAlive = 0,
    Regist = 1,
    Login = 2
}

public class Event
{
    public static void RegistEvent()
    {
        Dispatcher.Bind((uint)EventType.Regist, Regist);
    }

    public static void Regist(byte[] msg)
    {
        Console.WriteLine("regist successed.");
    }
}
