using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace File_Monitor
{
    public class MailService
    {
        private static MailService _Service = null;

        public static MailService getInstance()
        {
            if (_Service == null)
                _Service = new MailService();
            return _Service;
        }

        
        private ConfigParser configParser = null;
        private string SenderMailAddress { get; set; }
        private string ACCOUNT { get; set; }
        private string PASSWORD { get; set; }
        private string ValidMail { get; set; }
        private string Defalut_Mail_Topic { get; set; }
        private string Host { get; set; }
        private int Port { get; set; }
        private bool enableSsl { get; set; }

        
        private MailService()
        {
            // TODO: Add constructor logic here


            configParser = new ConfigParser(ConfigParser.CONFIG_PATH);

            Host = configParser.Mail_Host;
            Port = configParser.Mail_Port;
            enableSsl = configParser.Mail_EnableSsl;

            SenderMailAddress = configParser.Mail_Address;
            ACCOUNT = configParser.Mail_Account;
            PASSWORD = configParser.Mail_Password;

            Defalut_Mail_Topic = configParser.MailTopic;
        }

        public ConfigParser getConfigParser()
        {
            return configParser;
        }

        public void sendNoticeMail(string contents)
        {
            this.sendNoticeMail(
                configParser.MailTopic,
                configParser.To.ToArray(),
                configParser.Cc.ToArray(),
                contents);
        }

        public void sendNoticeMail(string topic, string[] targets, string[] cc, string contents)
        {
            MailMessage mail = new System.Net.Mail.MailMessage();
            SmtpClient smtpclient = new System.Net.Mail.SmtpClient();
            mail.Subject = topic;
            mail.From = new System.Net.Mail.MailAddress(SenderMailAddress, "File Mintor"); //寄件者
            mail.IsBodyHtml = false; //信件內文是否啟用HTML標記
            mail.Body = contents;
            mail.BodyEncoding = System.Text.Encoding.UTF8;

            //本文
            mail.To.Add(new MailAddress(ValidMail));
            for (int i = 0; i < targets.Length; i++)
            {
                if (!string.IsNullOrEmpty(targets[i]))
                    mail.To.Add(new MailAddress(targets[i]));
            }
            //副本
            if (cc != null && cc.Length != 0)
            {
                for (int i = 0; i < cc.Length; i++)
                {
                    mail.CC.Add(new MailAddress(cc[i]));
                }

            }
            //mail.Bcc.Add(new MailAddress(""));
            //設定SMTP Server 連線資訊
            smtpclient.Host = Host;
            smtpclient.Port = Port;
            smtpclient.EnableSsl = enableSsl;
            NetworkCredential MailCredentials = new NetworkCredential(ACCOUNT, PASSWORD); //SMTP Server驗證資訊
            smtpclient.Credentials = MailCredentials;
            smtpclient.Send(mail);

            //放掉宣告出來的MySmtp
            smtpclient = null;
            //放掉宣告出來的mail
            mail.Dispose();
        }

        
    }
}
