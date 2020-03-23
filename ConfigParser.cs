using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace File_Monitor
{
    public class ConfigParser
    {
        public string MailTopic { get; set; }
        public string Mail_Account { get; set; }
        public string Mail_Password { get; set; }
        public string Mail_Address { get; set; }



        private List<string> _to = new List<string>();
        private List<string> _cc = new List<string>();
        private List<string> _bcc = new List<string>();
        private List<string> _checks = new List<string>();
        private List<string> _ignores = new List<string>();

        public List<string> To
        {
            get { return _to; }
            set { _to = value; }
        }
        
        public List<string> Cc
        {
            get { return _cc; }
            set { _cc = value; }
        }
        
        public List<string> Bcc
        {
            get { return _bcc; }
            set { _bcc = value; }
        }
        

        public List<string> Ignores
        {
            get { return _ignores; }
        }
      
        public List<string> Checks
        {
            get { return _checks; }
        }

        

        public ConfigParser(string path)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNodeList mail_config = doc.DocumentElement.SelectNodes("/config/mail_server");
            MailTopic = mail_config[0].SelectSingleNode("mail_topic").InnerText;
            Mail_Account = mail_config[0].SelectSingleNode("mail_account").InnerText;
            Mail_Password = mail_config[0].SelectSingleNode("mail_password").InnerText;
            Mail_Address = mail_config[0].SelectSingleNode("mail_address").InnerText;
            
            Console.WriteLine("mail topic : " + MailTopic);
            Console.WriteLine("mail account : " + Mail_Account);
            Console.WriteLine("mail password : " + Mail_Password);
            Console.WriteLine("mail address : " + Mail_Address);

            XmlNodeList mail_to = doc.DocumentElement.SelectNodes("/config/mail_server/TO");
            XmlNodeList mail_cc = doc.DocumentElement.SelectNodes("/config/mail_server/CC");
            XmlNodeList mail_bcc = doc.DocumentElement.SelectNodes("/config/mail_server/BCC");

            for (int i = 0; i < mail_to.Count; i++)
            {
                string txt_to = mail_to.Item(i).InnerText;
                To.Add(txt_to);
                Console.WriteLine("mail to >> " + txt_to);
            }

            for (int i = 0; i < mail_cc.Count; i++)
            {
                string txt_cc = mail_cc.Item(i).InnerText;
                Cc.Add(txt_cc);
                Console.WriteLine("mail cc >> " + txt_cc);
            }

            for (int i = 0; i < mail_bcc.Count; i++)
            {
                string txt_bcc = mail_bcc.Item(i).InnerText;
                Bcc.Add(txt_bcc);
                Console.WriteLine("mail bcc >> " + txt_bcc);
            }

            XmlNodeList monitor_check = doc.DocumentElement.SelectNodes("/config/monitor/check");
            XmlNodeList monitor_ignore = doc.DocumentElement.SelectNodes("/config/monitor/ignore");

            for (int i = 0; i < monitor_check.Count; i++)
            {
                string txt_check = monitor_check.Item(i).InnerText;
                Checks.Add(txt_check);
                Console.WriteLine("check >> " + txt_check);
            }

            for (int i = 0; i < monitor_ignore.Count; i++)
            {
                string txt_ignore = monitor_ignore.Item(i).InnerText;
                Ignores.Add(txt_ignore);
                Console.WriteLine("ignore > " + txt_ignore);
            }

        }

    }
}
