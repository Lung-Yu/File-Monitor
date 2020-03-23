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
            List<string> targets = new List<string>();

            MailService mailService = MailService.getInstance();
            //mailService.sendNoticeMail(targets.ToArray(), mailContent);

            Console.ReadLine();
        }
    }
}
