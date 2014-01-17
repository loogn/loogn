﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loogn.WeiXinSDK.Message
{
    public abstract class EventBaseMsg : RecEventBaseMsg
    {
        public abstract EventType Event { get; }

        public override MsgType MsgType
        {
            get { return Message.MsgType.Event; }
        }

        public MyEventType MyEventType { get; set; }
    }
}
