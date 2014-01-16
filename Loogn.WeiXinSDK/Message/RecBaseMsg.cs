using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loogn.WeiXinSDK.Message
{
    public abstract class RecBaseMsg : RecEventBase
    {
        /// <summary>
        /// 消息id
        /// </summary>
        public Int64 MsgId { get; set; }
    }
}