using System;
using System.IO;
using ProtoBuf;

namespace World
{
    [ProtoContract(SkipConstructor = true, ImplicitFields = ImplicitFields.AllPublic)]
    public class UserInfo
    {
        //[ProtoMember(1)]
        public string Account { get; set; }

        //[ProtoMember(2)]
        public string Password { get; set; }

        //[ProtoMember(3)]
        public string Nickname { get; set; }
    }
}
