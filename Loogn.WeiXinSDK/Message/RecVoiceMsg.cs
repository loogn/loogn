using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loogn.WeiXinSDK.Message
{
    /// <summary>
    /// 接收的语音消息
    /// </summary>
    public class RecVoiceMsg:RecBaseMsg
    {
        /// <summary>
        /// 语音消息媒体id
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 语音格式，如amr，speex等
        /// </summary>
        public string Format{get;set;}

        public override MsgType MsgType
        {
            get { return Message.MsgType.voice; }
        }
    }
}
