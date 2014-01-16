using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loogn.WeiXinSDK.Message
{
    public class EventAttendMsg : EventBaseMsg
    {
        public override EventType Event
        {
            get { return EventType.subscribe; }
        }
    }
}
