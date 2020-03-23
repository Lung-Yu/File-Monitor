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
            string config_path = "config.xml";
            ConfigParser configParser = new ConfigParser(config_path);

            Console.ReadLine();
        }
    }
}
