using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Loogn.Common
{
    public abstract class UCNav : UserControl
    {
        public int Index { get; set; }

        string className = null;

        public string GetClass(int index)
        {
            if (this.Index == index)
            {
                if (string.IsNullOrEmpty(className))
                {
                    className = GetClass();
                }
                return className;
            }
            else
            {
                return string.Empty;
            }
        }

        protected abstract string GetClass();
    }
}
