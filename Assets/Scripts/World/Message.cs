using System;
using System.IO;
using System.Collections.Generic;
using ProtoBuf;

namespace ForestGuard
{
    [ProtoContract(SkipConstructor = true)]
    public class ID
    {
        [ProtoMember(1)]
        public uint Id { get; set; }

        [ProtoMember(2)]
        public string Nickname { get; set; }
    }

    [ProtoContract(SkipConstructor = true)]
    public class Account
    {
        [ProtoMember(1)]
        public string Id { get; set; }

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
        public uint Id { get; set; }

        [ProtoMember(2)]
        public string Nickname { get; set; }
    }

    [ProtoContract(SkipConstructor = true)]
    public class RoomInfo
    {
        [ProtoMember(1)]
        public uint Id { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3)]
        public List<PlayerInfo> Players { get; set; }
    }

    [ProtoContract(SkipConstructor = true)]
    public class RoomList
    {
        [ProtoMember(1)]
        public List<RoomInfo> List { get; set; }
    }

    [ProtoContract(SkipConstructor = true)]
    public class JoinOrLeaveRoom
    {
        [ProtoMember(1)]
        public uint UserId { get; set; }

        [ProtoMember(2)]
        public uint RoomId { get; set; }
    }

    [ProtoContract(SkipConstructor = true)]
    public class SeatTable
    {
        [ProtoMember(1)]
        public uint RoomId { get; set; }

        [ProtoMember(2)]
        public List<PlayerInfo> Players { get; set; }
    }
}
