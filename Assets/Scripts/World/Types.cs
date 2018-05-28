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
	Regist_Ok = 1,
	Regist_Fail = 2,
	Login_Ok = 3,
	Login_AcNotExist = 4,
	Login_PwError = 5,
    MaxType
}
