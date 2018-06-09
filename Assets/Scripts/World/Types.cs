using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestGuard
{
    public enum RequestType : uint
    {
        KeepAlive = 0,
        Regist = 1,
        Login = 2,
        FetchRoomList = 3,
        CreateRoom = 4,
        EnterRoom = 5,
        LeaveRoom = 6,
        MaxType
    }

    public enum ResponseType : uint
    {
        KeepAlive = 0,
        Regist_Ok = 1,
        Regist_Fail = 2,
        Login_Ok = 3,
        Login_PwError = 4,
        Login_AcNotExist = 5,
        //Login_AlreadyLogged = 6,
        FetchRoomList = 6,
        CreateRoom_Ok = 7,
        CreateRoom_Fail = 8,
        EnterRoom_Ok = 9,
        EnterRoom_Full = 10,
        EnterRoom_Started = 11,
        EnterRoom_NotExist = 12,
        //Room_Updated =14,
        MaxType
    }
}
