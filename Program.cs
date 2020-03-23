using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Monitor
{
    class Program
    {
        static void Main(string[] args)
        {
            //string config_path = "config.xml";
            //ConfigParser configParser = new ConfigParser(config_path);

<<<<<<< HEAD
            Console.ReadLine();
=======
            string mailTopic = "";
            List<string> targets = new List<string>();
            string mailContent = "";


            MailService mailService = MailService.getInstance();
            mailService.sendNoticeMail(mailTopic, targets.ToArray(), mailContent);
>>>>>>> mail
        }
    }
}
