﻿using System;
using System.IO;
using System.Collections.Generic;
using ProtoBuf;

namespace ForestGuard
{
    [ProtoContract(SkipConstructor = true)]
    public class Account
    {
        [ProtoMember(1)]
        public string ID { get; set; }

        [ProtoMember(2)]
        public string Password { get; set; }
    }

    [ProtoContract(SkipConstructor = true)]
    public class UserInfo
    {
        [ProtoMember(1)]
        public string Account { get; set; }

        [ProtoMember(2)]
        public string Password { get; set; }

        [ProtoMember(3)]
        public string Nickname { get; set; }
    }

    [ProtoContract(SkipConstructor = true)]
    public class PlayerInfo
    {
        [ProtoMember(1)]
        public string Account { get; set; }

        [ProtoMember(2)]
        public string Nickname { get; set; }
    }

    [ProtoContract(SkipConstructor = true)]
    class RoomInfo
    {
        [ProtoMember(1)]
        public uint Id { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3)]
        public List<PlayerInfo> PlayList { get; set; }
    }
}
