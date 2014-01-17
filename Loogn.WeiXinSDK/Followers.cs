using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loogn.WeiXinSDK
{
    public class Followers
    {
        public int total { get; set; }
        public int count { get; set; }

        public Data data { get; set; }

        public string next_openid { get; set; }

        public class Data
        {
            public List<string> openid { get; set; }
        }

        public ReturnCode error { get; set; }
    }
}
