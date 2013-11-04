using System;
using System.Net.Mail;
using System.Text;
using System.Web.Mail;


namespace Loogn.Common
{
    /// <summary>
    /// 发送Email帮助类，需要实例化
    /// </summary>
    public class EmailHelper
    {
        public static string GetLoginUrl(string email)
        {
            string[] part = email.Split('@');
            if (part.Length != 2)
                return string.Empty;
            else
            {
                string doma = part[1];
                switch (doma)
                {
                    case "gmail.com":
                    case "189.cn":
                    case "188.com":
                    case "263.net":
                    case "hotmail.com":
                    case "live.com":
                    case "live.cn":
                        return "http://www." + doma;
                    default:
                        return "http://mail." + doma;
                }
            }
        }

        private int _ServerPort = 25;
        /// <summary>
        /// 服务端口号
        /// </summary>
        public int ServerPort
        {
            get
            {
                return _ServerPort;
            }
            set
            {
                _ServerPort = value;
            }
        }

        private String _FromEmail;
        /// <summary>
        /// 发信人邮箱
        /// </summary>
        public String FromEmail
        {
            get
            {
                return _FromEmail;
            }
            set
            {
                _FromEmail = value;
            }
        }

        private String _FromEmailPwd;
        /// <summary>
        /// 发信人邮箱密码
        /// </summary>
        public String FromEmailPwd
        {
            get
            {
                return _FromEmailPwd;
            }
            set
            {
                _FromEmailPwd = value;
            }
        }

        private String _ToEmail;
        /// <summary>
        /// 收信人邮箱
        /// </summary>
        public String ToEmail
        {
            get
            {
                return _ToEmail;
            }
            set
            {
                _ToEmail = value;
            }
        }

        private String _Subject;
        /// <summary>
        /// 邮件标题
        /// </summary>
        public String Subject
        {
            get
            {
                return _Subject;
            }
            set
            {
                _Subject = value;
            }
        }

        private String _Content;
        /// <summary>
        /// 邮件内容
        /// </summary>
        public String Content
        {
            get
            {
                return _Content;
            }
            set
            {
                _Content = value;
            }
        }

        private Boolean _IsHtml = true;
        /// <summary>
        /// 邮件内容是否是html格式
        /// </summary>
        public Boolean IsHtml
        {
            get
            {
                return _IsHtml;
            }
            set
            {
                _IsHtml = value;
            }
        }

        private string _smtpServer;
        /// <summary>
        /// Smtp服务
        /// </summary>
        public string SmtpServer
        {
            get { return _smtpServer; }
            set { _smtpServer = value; }
        }

        private Encoding _encoding = Encoding.UTF8;
        /// <summary>
        ///  编码
        /// </summary>
        public Encoding Encoding {
            get { return _encoding; }
            set { _encoding = value; }
        }

        
        /// <summary>
        /// 通用的发送
        /// </summary>
        [Obsolete("其实还是比较通用")]
        public void SendToEmailOld()
        {
            System.Web.Mail.MailMessage message = new System.Web.Mail.MailMessage();
            message.Subject = Subject;
            message.BodyFormat = IsHtml ? MailFormat.Html : MailFormat.Text; // 设置邮件正文为html 格式 
            message.BodyEncoding = Encoding;
            message.Body = Content; // 设置邮件内容 
            message.From = FromEmail;
            message.To = ToEmail;
            String sendUser;
            int s = FromEmail.IndexOf('<');
            int e = FromEmail.IndexOf('>');
            if (s > 0 && e > 0)
            {
                FromEmail = FromEmail.Substring(s + 1, e - s - 1);
            }
            String[] EmailParts = FromEmail.Split("@".ToCharArray(), 2);
            sendUser = EmailParts[0];
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");//设置服务器需要身份验证
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", sendUser); //设置用户名
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", FromEmailPwd);//设置密码 
            SmtpMail.SmtpServer = SmtpServer;
            SmtpMail.Send(message);//发送邮件。
        }

        /// <summary>
        /// 用指定的编码发
        /// </summary>
        /// <param name="encoding">编码</param>
        public void SendToEMail()
        {
            System.Net.Mail.MailMessage MM = new System.Net.Mail.MailMessage(FromEmail, ToEmail, Subject, Content);
            MM.Priority = System.Net.Mail.MailPriority.High;
            MM.IsBodyHtml = IsHtml;
            MM.BodyEncoding = Encoding;
            String sendUser;
            int s=FromEmail.IndexOf('<');
            int e=FromEmail.IndexOf('>');
            if (s>0 && e>0)
            {
                FromEmail = FromEmail.Substring(s+1, e - s-1);
            }
            String[] EmailParts = FromEmail.Split("@".ToCharArray(), 2);
            sendUser = EmailParts[0];

            SmtpClient SC = new SmtpClient(SmtpServer, ServerPort);
            SC.DeliveryMethod = SmtpDeliveryMethod.Network;

            SC.Timeout = 100000;
            SC.Credentials = new System.Net.NetworkCredential(sendUser, FromEmailPwd);
            SC.Send(MM);
        }
    }
}
