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
        public ConfigParser(string path)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNodeList mail_config = doc.DocumentElement.SelectNodes("/config/mail_server");
            string mail_topic = mail_config[0].SelectSingleNode("mail_topic").InnerText;
            Console.WriteLine("mail topic : " + mail_topic);


            XmlNodeList monitor_check = doc.DocumentElement.SelectNodes("/config/monitor/check");
            XmlNodeList monitor_ignore = doc.DocumentElement.SelectNodes("/config/monitor/ignore");

            for (int i = 0; i < monitor_check.Count; i++)
            {
                Console.WriteLine("check >> " + monitor_check.Item(i).InnerText);
            }

            for (int i = 0; i < monitor_ignore.Count; i++)
            {
                Console.WriteLine("ignore > " + monitor_ignore.Item(i).InnerText);
            }

        }

    }
}
