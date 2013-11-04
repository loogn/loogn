using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loogn.DB
{
    public class PageResult
    {
        public List<dynamic> Rows { get; set; }
        public int TotalCount { get; set; }
        public PageResult()
        {
            Rows = new List<dynamic>();
        }
    }
    public class PageResult<T>
    {
        public List<T> Rows { get; set; }
        public int TotalCount { get; set; }
        public PageResult()
        {
            Rows = new List<T>();
        }
    }

}
