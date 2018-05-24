﻿using System;
using System.IO;
using ProtoBuf;

namespace World
{
    [ProtoContract(SkipConstructor = true, ImplicitFields = ImplicitFields.AllPublic)]
    public class Account
    {
        //[ProtoMember(1)]
        public string ID { get; set; }

        //[ProtoMember(2)]
        public string Password { get; set; }
    }
}