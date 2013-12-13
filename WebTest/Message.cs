using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest
{
    public class Message
    {
        public int ID { get; set; }
        public int FromID { get; set; }
        public string FromUser { get; set; }
        public int ToID { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}