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

            string mailTopic = "";
            List<string> targets = new List<string>();
            string mailContent = "";


            MailService mailService = MailService.getInstance();
            mailService.sendNoticeMail(mailTopic, targets.ToArray(), mailContent);
        }
    }
}
