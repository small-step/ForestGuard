using System;
using System.Collections.Generic;
using System.Text;

public class Event
{
    public static void RegistEvent()
    {
        Dispatcher.Bind((uint)ResponseType.RegistOk, Regist);
    }

    public static void Regist(byte[] msg)
    {
        Console.WriteLine("regist successed.");
    }
}
