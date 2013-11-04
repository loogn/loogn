using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loogn.Common
{
    public class HTMLBuilder
    {
        public const string Break = "<br/>";
        public const string Space = "&nbsp;";
        static string GetSpaces(int count)
        {
            string[] spaces = new string[count];
            for (int i = 0; i < count; i++)
                spaces[i] = Space;
            return string.Concat(spaces);
        }

        public static class Target
        {
            public const string Blank = "_blank";
            public const string Self = "_self";
            public const string Top = "_top";
            public const string Parent = "_parent";
        }

        public static class EventName
        {
            public const string OnClick = "onclick";
            public const string OnMouseOut = "onmouseout";
            public const string OnMouseOver = "onmouseover";
            public const string OnChange = "onchange";
            public const string OnKeyUp = "onkeyup";
            public const string OnKeyDown = "onkeydown";
            public const string OnKeyPress = "onkeypress";
        }


        private StringBuilder _html = new StringBuilder();
        public static HTMLBuilder NewHTML()
        {
            return new HTMLBuilder();
        }
        public static HTMLBuilder NewHTML(string input)
        {
            return NewHTML().Append(input);
        }


        public HTMLBuilder Append(string input)
        {
            _html.Append(input);
            return this;
        }
        public HTMLBuilder Append(string format, object arg0)
        {
            _html.AppendFormat(format, arg0);
            return this;
        }
        public HTMLBuilder Append(string format, params object[] args)
        {
            _html.AppendFormat(format, args);
            return this;
        }

        public HTMLBuilder AppendSpace(int count)
        {
            _html.Append(GetSpaces(count));
            return this;
        }
        public HTMLBuilder AppendBreak()
        {
            _html.Append("<br/>");
            return this;
        }

        public HTMLBuilder AppendLink(string text, string url)
        {
            _html.AppendFormat("<a href='{0}'>{1}</a>", url, text);
            return this;
        }
        public HTMLBuilder AppendLink(string text, string url, string target)
        {
            _html.AppendFormat("<a href='{0}' target='{1}'>{2}</a>", url, target, text);
            return this;
        }

        public HTMLBuilder AppendImage(string src, string alt)
        {
            _html.AppendFormat("<img src=\"{0}\" alt=\"{1}\"  />", src, alt);
            return this;
        }
        public HTMLBuilder AppendImage(string src, string alt, string className)
        {
            _html.AppendFormat("<img src=\"{0}\" alt=\"{1}\" class=\"{2}\"  />", src, alt, className);
            return this;
        }
        public HTMLBuilder AppendImage(string src, string alt, string className,string style)
        {
            _html.AppendFormat("<img src=\"{0}\" alt=\"{1}\" class=\"{2}\" style=\"{3}\"  />", src, alt, className, style);
            return this;
        }


        #region 和String转换
        public static implicit operator string(HTMLBuilder html)
        {
            return html._html.ToString();
        }
        public static implicit operator HTMLBuilder(string input)
        {
            return NewHTML(input);
        }
        public override string ToString()
        {
            return this._html.ToString();
        }
        #endregion 

    }
}
