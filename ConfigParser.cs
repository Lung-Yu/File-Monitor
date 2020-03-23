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

        private List<string> _checks = new List<string>();
        private List<string> _ignores = new List<string>();

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
            
            Console.WriteLine("mail topic : " + MailTopic);


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
