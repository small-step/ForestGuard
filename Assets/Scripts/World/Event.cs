using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event
{
    public static void RegistEvent()
    {
        Dispatcher.Bind((uint)ResponseType.KeepAlive, KeepAlive);
        Dispatcher.Bind((uint)ResponseType.Regist_Ok, RegistOk);
        Dispatcher.Bind((uint)ResponseType.Regist_Fail, RegistFailed);
        Dispatcher.Bind((uint)ResponseType.Login_Ok, LoginOk);
        Dispatcher.Bind((uint)ResponseType.Login_AcNotExist, LoginNoAccount);
        Dispatcher.Bind((uint)ResponseType.Login_PwError, LoginPasswordError);
    }

    public static void KeepAlive(byte[] msg)
    {
        Debug.Log("keep alive.");
    }

    public static void RegistOk(byte[] msg)
    {
        Debug.Log("Regist successed");
    }

    public static void RegistFailed(byte[] msg)
    {
        Debug.Log("Regist failed");
    }

    public static void LoginOk(byte[] msg)
    {
        //SceneManager.LoadSceneAsync(1);
    }
    
    public static void LoginNoAccount(byte[] msg)
    {
        Debug.Log("Account not exist");
    }

    public static void LoginPasswordError(byte[] msg)
    {
        Debug.Log("Password error");
    }
}
