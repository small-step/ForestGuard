using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum RequestType : uint
{
    KeepAlive = 0,
    Regist = 1,
    Login = 2,
    MaxType
}

public enum ResponseType : uint
{
    KeepAlive = 0,
    RegistOk = 1,
    RegistFailed = 2,
    MaxType
}
