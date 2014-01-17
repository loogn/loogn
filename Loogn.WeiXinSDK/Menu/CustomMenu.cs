using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loogn.WeiXinSDK.Menu
{
    public class CustomMenu
    {
        public List<BaseButton> button = new List<BaseButton>();

        public virtual string GetJSON()
        {
            return Util.ToJson(this);
        }
    }
}
