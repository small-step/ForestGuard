using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace ForestGuard
{
    public class Event : MonoBehaviour
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
            //Debug.Log("keep alive.");
        }

        public static void RegistOk(byte[] msg)
        {
            LoginController.State = 1;
            Debug.Log("Regist successed");
        }

        public static void RegistFailed(byte[] msg)
        {
            Debug.Log("Regist failed");
            LoginController.State = 0;
            LoginController.Message = "账号已被注册";
        }

        public static void LoginOk(byte[] msg)
        {
            LoginController.State = 2;
            //SceneManager.LoadSceneAsync(1);
        }

        public static void LoginNoAccount(byte[] msg)
        {
            Debug.Log("Account not exist");
            LoginController.State = 0;
            LoginController.Message = "账号不存在";
        }

        public static void LoginPasswordError(byte[] msg)
        {
            Debug.Log("Password error");
            LoginController.State = 0;
            LoginController.Message = "密码不正确";
        }
    }
}