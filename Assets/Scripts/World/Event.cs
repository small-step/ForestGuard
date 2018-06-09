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
            Dispatcher.Bind((uint)ResponseType.FetchRoomList, FetchRoomList);
            Dispatcher.Bind((uint)ResponseType.CreateRoom_Ok, CreateRoomOk);
            Dispatcher.Bind((uint)ResponseType.CreateRoom_Fail, CreateRoomFail);
            Dispatcher.Bind((uint)ResponseType.EnterRoom_Ok, EnterRoomOk);
            Dispatcher.Bind((uint)ResponseType.EnterRoom_Full, EnterRoomFull);
            Dispatcher.Bind((uint)ResponseType.EnterRoom_Started, EnterRoomStarted);
            Dispatcher.Bind((uint)ResponseType.EnterRoom_NotExist, EnterRoomNotExist);
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
            var id = Proto.Deserialize<ID>(msg);
            User.Id = id.Id;
            User.Nickname = id.Nickname;
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

        //public static void LoginAlreadyLogged(byte[] msg)
        //{
        //    Debug.Log("Account Already Logged in");
        //    LoginController.State = 0;
        //    LoginController.Message = "账号已经登陆";
        //}

        public static void FetchRoomList(byte[] msg)
        {
            LobbyController.RoomList = Proto.Deserialize<RoomList>(msg);
            LobbyController.LobbyState = 1;
            string log = string.Format("room num: {0}", LobbyController.RoomList.List.Count);
            Debug.Log(log);
        }

        public static void CreateRoomOk(byte[] msg)
        {
            var seat = Proto.Deserialize<RoomSeat>(msg);
            User.RoomId = seat.RoomId;
            User.SeatId = seat.SeatId;
            LobbyController.LobbyState = 2;
            string log = string.Format("room id: {0}, seat id: {1}", seat.RoomId, seat.SeatId);
            Debug.Log(log);
        }

        public static void CreateRoomFail(byte[] msg)
        {
            Debug.Log("Create room failed");
        }

        public static void EnterRoomOk(byte[] msg)
        {
            var seat = Proto.Deserialize<RoomSeat>(msg);
            User.RoomId = seat.RoomId;
            User.SeatId = seat.SeatId;
            LobbyController.LobbyState = 2;
            string log = string.Format("room id: {0}, seat id: {1}", seat.RoomId, seat.SeatId);
            Debug.Log(log);
        }

        public static void EnterRoomFull(byte[] msg)
        {
            Debug.Log("Room is full");
        }

        public static void EnterRoomStarted(byte[] msg)
        {
            Debug.Log("Room started the game");
        }

        public static void EnterRoomNotExist(byte[] msg)
        {
            Debug.Log("Room not exist");
        }

        //public static void UpdateRoomMembers(byte[] msg)
        //{
        //    Debug.Log("Get room members list");
        //}
    }
}